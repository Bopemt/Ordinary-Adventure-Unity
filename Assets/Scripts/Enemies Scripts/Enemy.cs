using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger,
    shooting
}

public class Enemy : MonoBehaviour
{
    [Header("State Machine")]
    public EnemyState currentState;

    [Header("Enemy Stats")]
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public float moveSpeed;
    public float chaseRadius;
    public float attackRadius;
    private Vector2 homePosition;

    [Header("Death Effect")]
    public GameObject deathEffect;
    public LootTable thisLoot;

    [Header("Render Order")]
    public int defaultOrder;
    public SpriteRenderer mySprite;

    [Header("Target")]
    public Transform target;
    public Rigidbody2D myRigidbody2D;

    [Header("Animator")]
    public Animator anim;

    [Header("Death Signals")]
    public SignalCore roomSignal;
    
    public void Start()
    {
        defaultOrder = mySprite.sortingOrder;
        mySprite = GetComponent<SpriteRenderer>();
        currentState = EnemyState.idle;
        myRigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        anim.SetBool("isWake", true);
    }

    public void Awake()
    {
        health = maxHealth.initialValue;
        homePosition = transform.position;
    }

    private void OnEnable()
    {
        transform.position = homePosition;
        health = maxHealth.initialValue;
        currentState = EnemyState.idle;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            MakeLoot();
            if (roomSignal != null)
            {
                roomSignal.Raise();
                Debug.Log("Here");
            }
            this.gameObject.SetActive(false);
            Death();
        }
    }

    private void MakeLoot()
    {
        if(thisLoot != null)
        {
            PowerUp current = thisLoot.LootPowerUp();
            if(current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    private void Death()
    {
        if(deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        TakeDamage(damage);
        if(health > 0)
            StartCoroutine(KnockCo(myRigidbody, knockTime));
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

    public void CheckLayer()
    {
        if (target.transform.position.y > transform.position.y)
        {
            mySprite.sortingOrder = defaultOrder + 1;
        }
        else
        {
            mySprite.sortingOrder = defaultOrder - 1;
        }
    }
}
