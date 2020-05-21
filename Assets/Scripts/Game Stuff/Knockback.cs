using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float thrust;
    [SerializeField] private float knockTime;
    [SerializeField] private string otherTag;
    //[SerializeField] private GenericStateMachine stateMachine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && other.isTrigger)
        {
            Rigidbody2D temp = other.GetComponentInParent<Rigidbody2D>();
            if (temp)
            {
                Vector2 direction = other.transform.position - transform.position;
                temp.DOMove((Vector2)other.transform.position +
                    (direction.normalized * thrust), knockTime);
            }
        }

        //if (other.gameObject.CompareTag(otherTag) && other.isTrigger)
        //{
        //    Rigidbody2D temp = other.GetComponentInParent<Rigidbody2D>();
        //    if (temp != null)
        //    {
        //        Vector3 difference = temp.transform.position - transform.position;
        //        difference = difference.normalized * thrust;
        //        temp.DOMove(temp.transform.position + difference, knockTime);
        //        //temp.AddForce(difference, ForceMode2D.Impulse);

        //        //if (other.gameObject.CompareTag("enemy"))
        //        //{
        //        //    temp.GetComponent<Enemy>().currentState = EnemyState.stagger;
        //        //    other.GetComponent<Enemy>().Knock(temp, knockTime);
        //        //}
        //        //if (other.GetComponentInParent<PlayerMovement>().currentState != PlayerState.stagger)
        //        //{
        //        //    if (other.GetComponentInParent<PlayerMovement>().currentState != PlayerState.stagger)
        //        //    {
        //        //        temp.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
        //        //        other.GetComponentInParent<PlayerMovement>().Knock(knockTime);
        //        //    }
        //        //}
        //    }
        //}

        //if (other.gameObject.CompareTag("enemy") && gameObject.CompareTag("enemy"))
        //{
        //    return;
        //}
    }
}
