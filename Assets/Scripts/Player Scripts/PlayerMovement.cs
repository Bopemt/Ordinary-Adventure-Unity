using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    [SerializeField] private PlayerFloatValue speedPFV;

    [Header("New")]
    [SerializeField] private AnimatorController anim;
    [SerializeField] private VectorValue startingPosition;
    [SerializeField] private GenericStateMachine myState;
    [SerializeField] private RecieveItem myItem;

    [Header("Attack Stuff")]
    [SerializeField] private GenericAbility currentAbility;
    [SerializeField] private GenericAbility rangeAttack;
    [SerializeField] private ItemValue currentWeapon;
    [SerializeField] private GenericEnergy playerEnergy;

    private Vector2 tempMovement = Vector2.down;
    private Vector2 faceDirection = Vector2.down;

    void Start()
    {
        myState.ChangeState(GenericState.idle);
        transform.parent.position = startingPosition.value;
        speed = speedPFV.value;
    }

    void Update()
    {
        if (myState.myState == GenericState.recieveItem)
        {
            tempMovement = Vector2.zero;
            Motion(tempMovement);
            if (Input.GetButtonDown("Interact"))
            {
                myState.ChangeState(GenericState.idle);
                anim.SetAnimParameter("recieveItem", false);
                myItem.ChangeSpriteState();
            }
            return;
        }

        if (!IsRestrictedState(myState.myState))
        {
            GetInput();
            SetAnimation();
        }
    }

    public void SetState(GenericState newState)
    {
        myState.ChangeState(newState);
    }

    public bool IsRestrictedState(GenericState currentState)
    {
        if (currentState == GenericState.attack || currentState == GenericState.ability || currentState == GenericState.pause 
            || myState.myState == GenericState.interact || myState.myState == GenericState.inventory || myState.myState == GenericState.shop)
        {
            return true;
        }
        return false;
    }

    void GetInput()
    {
        if (Input.GetButtonDown("Attack") /*&& myState.myState != GenericState.interact && myState.myState != GenericState.inventory*/)
        {
            if (currentWeapon.value)
            {
                if (!currentWeapon.value.rangeWeapon)
                {
                    StartCoroutine(AttackCo(currentWeapon.value.attackDuration));
                    tempMovement = Vector2.zero;
                    Motion(tempMovement);
                }
                else
                {
                    StartCoroutine(RangeAttackCo(currentWeapon.value.attackDuration));
                    tempMovement = Vector2.zero;
                    Motion(tempMovement);
                }
            }
        }
        else if (Input.GetButtonDown("Ability"))
        {
            if (currentAbility)
            {
                StartCoroutine(AbilityCo(currentAbility.duration));
                tempMovement = Vector2.zero;
                Motion(tempMovement);
            }
        }
        else if (tempMovement.magnitude >= 0/*myState.myState != GenericState.interact && myState.myState != GenericState.inventory*/)
        {
            tempMovement.x = Input.GetAxisRaw("Horizontal");
            tempMovement.y = Input.GetAxisRaw("Vertical");
            Motion(tempMovement);
        }
        else
        {
            tempMovement = Vector2.zero;
            Motion(tempMovement);
        }
    }

    void SetAnimation()
    {
        if (tempMovement.magnitude > 0)
        {
            anim.SetAnimParameter("moveX", Mathf.Round(tempMovement.x));
            anim.SetAnimParameter("moveY", Mathf.Round(tempMovement.y));
            anim.SetAnimParameter("moving", true);
            SetState(GenericState.walk);
            faceDirection = tempMovement;
        }
        else
        {
            anim.SetAnimParameter("moving", false);
            if (myState.myState != GenericState.attack && myState.myState != GenericState.interact && myState.myState != GenericState.inventory 
                && myState.myState != GenericState.ability && myState.myState != GenericState.shop)
            {
                SetState(GenericState.idle);
            }
        }
    }

    public IEnumerator AttackCo(float weaponAttackDuration)
    {
        anim.anim.speed = 0.3f / weaponAttackDuration;
        myState.ChangeState(GenericState.attack);
        anim.SetAnimParameter("attacking", true);
        yield return new WaitForSeconds(weaponAttackDuration);
        anim.SetAnimParameter("attacking", false);
        myState.ChangeState(GenericState.idle);
        anim.anim.speed = 1;
    }

    public IEnumerator RangeAttackCo(float abilityDuration)
    {
        SetState(GenericState.ability);
        rangeAttack.Ability(transform.position, faceDirection, playerEnergy, anim.anim, myRigidbody);
        yield return new WaitForSeconds(abilityDuration);
        SetState(GenericState.idle);
    }

    public IEnumerator AbilityCo(float abilityDuration)
    {
        //ghost.makeGhost = true;
        SetState(GenericState.ability);
        currentAbility.Ability(transform.position, faceDirection, playerEnergy, anim.anim, myRigidbody);
        yield return new WaitForSeconds(abilityDuration);
        SetState(GenericState.idle);
        //ghost.makeGhost = false;
    }
}