using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : Movement
{
    [SerializeField] protected AnimatorController anim;
    [SerializeField] protected float chaseRadius;
    [SerializeField] protected float attackRadius;
    protected float targetDistance;
    public Transform target;
    public bool inAttackRange = false;

    protected virtual void Update()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        if (targetDistance < chaseRadius && targetDistance > attackRadius)
        {
            Vector2 temp = (Vector2)(target.position - transform.position);
            ChangeAnim(temp);
            anim.SetAnimParameter("isWake", true);
            Motion(temp);
            inAttackRange = false;
        }
        else if (targetDistance <= attackRadius)
        {
            Vector2 temp = (Vector2)(target.position - transform.position);
            ChangeAnim(temp);
            Motion(-temp);
            inAttackRange = true;
        }
        else
        {
            anim.SetAnimParameter("isWake", false);
            Motion(Vector2.zero);
            inAttackRange = false;
        }
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }

    public virtual void ChangeAnim(Vector2 direction)
    {
        direction = direction.normalized;
        anim.SetAnimParameter("moveX", direction.x);
        anim.SetAnimParameter("moveY", direction.y);
    }
}
