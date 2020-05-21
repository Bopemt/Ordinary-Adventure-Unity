using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolFollow : SimpleFollow
{
    [SerializeField] private Transform[] path;
    [SerializeField] private int currentPoint;
    [SerializeField] private float roundingDistance;

    protected override void Update()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        if (targetDistance < chaseRadius && targetDistance > attackRadius)
        {
            Vector2 temp = (Vector2)(target.position - transform.position);
            ChangeAnim(temp);
            Motion(temp);
            inAttackRange = false;
            anim.SetAnimParameter("isWake", true);
        }
        else if (targetDistance <= attackRadius)
        {
            Vector2 temp = (Vector2)(target.position - transform.position);
            ChangeAnim(temp);
            Motion(-temp);
            inAttackRange = true;
            anim.SetAnimParameter("isWake", true);
        }
        else
        {
            anim.SetAnimParameter("isWake", true);
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                Vector2 temp = (Vector2)(path[currentPoint].position - transform.position);
                ChangeAnim(temp);
                Motion(temp);
            }
            else
            {
                ChangeGoal();
            }
        }
    }

    private void ChangeGoal()
    {
        if (currentPoint == path.Length - 1)
        {
            currentPoint = 0;
        }
        else
        {
            currentPoint++;
        }
    }
}
