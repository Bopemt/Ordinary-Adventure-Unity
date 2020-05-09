using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    [Header("Connections")]
    public VectorValue startingPosition;
    public Inventory playerInventory;
    public SpriteRenderer recievedItemSprite;

    [Header("Health")]
    public FloatValue currentHealth;
    public SignalCore playerHealthSignal;

    [Header("Energy")]
    public FloatValue currentEnergy;
    public SignalCore playerEnergySignal;
    public float energyRecoveryAmount;

    [Header("Range Attack")]
    public GameObject projectile;
    public GameObject bowObject;
    public Item bow;
    public float fireDelay;
    private float fireDelaySeconds;
    public bool canFire;

    [Header("Weapon")]
    public int weaponSlot;

    [Header("IFrame Stuff")]
    public Color flashColor;
    public Color regularColor;
    public float flashDuration;
    public int numberOfFlashes;
    private SpriteRenderer mySprite;
    private GameObject kinematicBody;
    
    void Start()
    {
        canFire = false;
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        playerHealthSignal.Raise();
        playerEnergySignal.Raise();
        transform.position = startingPosition.initialValue;
        mySprite = GetComponent<SpriteRenderer>();
        kinematicBody = transform.Find("player_Kinematic").gameObject;
    }
    
    void Update()
    {
        if (currentEnergy.RuntimeValue < currentEnergy.initialValue)
        {
            currentEnergy.RuntimeValue += energyRecoveryAmount;
            playerEnergySignal.Raise();
            if (currentEnergy.RuntimeValue > currentEnergy.initialValue)
            {
                currentEnergy.RuntimeValue = currentEnergy.initialValue;
                playerEnergySignal.Raise();
            }
        }

        if (!canFire)
        {
            fireDelaySeconds -= Time.deltaTime;
            if (fireDelaySeconds <= 0)
            {
                canFire = true;
                fireDelaySeconds = fireDelay;
            }
        }

        if (currentState == PlayerState.interact)
        {
            return;
        }
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("Attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            if (weaponSlot == 0)
            {
                StartCoroutine(AttackCo());
            }
            else if(weaponSlot == 1)
            {
                if (canFire)
                {
                    canFire = false;
                    StartCoroutine(RangeAttackCo());
                }
            }
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }

        if (Input.GetKey(KeyCode.Alpha1)) { weaponSlot = 0; }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            if(playerInventory.CheckForItem(bow))
            weaponSlot = 1;
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    private IEnumerator RangeAttackCo()
    {
        MakeBow();
        if (currentEnergy.RuntimeValue >= projectile.GetComponent<Arrow>().energyCost)
        {
            currentState = PlayerState.attack;
            MakeArrow();
            yield return new WaitForSeconds(0.1f);
            currentState = PlayerState.idle;
        }
        if (currentState != PlayerState.attack)
        {
            currentState = PlayerState.walk;
        }
    }

    private void MakeArrow()
    {
        Vector2 tempArrow = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));

        Arrow arrow = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Arrow>();
        currentEnergy.RuntimeValue -= arrow.energyCost;
        playerEnergySignal.Raise();
        arrow.Setup(tempArrow, ChooseBowArrowDirection());

        //Vector2 tempArrow = myRigidbody.transform.position - transform.position;
        tempArrow = tempArrow.normalized * 2;
        myRigidbody.AddForce(-tempArrow, ForceMode2D.Impulse);
        StartCoroutine(KnockCo(0.1f));
    }

    private void MakeBow()
    {
        Vector3 tempBow = new Vector3(animator.GetFloat("moveX") / 2, animator.GetFloat("moveY") / 2, 0);
        Bow bow = Instantiate(bowObject, transform.position, Quaternion.identity).GetComponent<Bow>();
        bow.Setup(ChooseBowArrowDirection(), tempBow + transform.position);
    }

    Vector3 ChooseBowArrowDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg - 45;
        return new Vector3(0, 0, temp);
    }

    public void RaiseItem()
    {
        if (playerInventory.currentItem != null)
        {
            if (currentState != PlayerState.interact)
            {
                animator.SetBool("recieve", true);
                currentState = PlayerState.interact;
                recievedItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                animator.SetBool("recieve", false);
                currentState = PlayerState.idle;
                recievedItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }
        }
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);
    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {
            StartCoroutine(KnockCo(knockTime));
            StartCoroutine(FlashCo());
        }
        else
        {
            currentHealth.RuntimeValue = 0;
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

    private IEnumerator FlashCo()
    {
        int temp = 0;
        gameObject.layer = 15;
        kinematicBody.layer = 15;
        while (temp < numberOfFlashes)
        {
            mySprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        gameObject.layer = 12;
        kinematicBody.layer = 12;
    }
}
