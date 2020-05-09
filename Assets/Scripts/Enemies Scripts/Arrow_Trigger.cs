using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Trigger : MonoBehaviour
{
    //public BoxCollider2D myCollider;
    public GameObject myLog;
    
    private float knockTime;
    private float damage;
    private float thrust;

    // Start is called before the first frame update
    void Start()
    {
        myLog = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("projectile"))
        {
            knockTime = other.GetComponent<Knockback>().knockTime;
            damage = other.GetComponent<Knockback>().damage;
            thrust = other.GetComponent<Knockback>().thrust;
            Vector2 difference = myLog.transform.position - other.transform.position;
            difference = difference.normalized * thrust;
            myLog.GetComponent<Rigidbody2D>().AddForce(difference, ForceMode2D.Impulse);
            myLog.GetComponent<log>().currentState = EnemyState.stagger;
            myLog.GetComponent<log>().Knock(myLog.GetComponent<Rigidbody2D>(), knockTime, damage);
        }
    }
}
