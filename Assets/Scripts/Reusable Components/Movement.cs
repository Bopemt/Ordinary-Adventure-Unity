using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Rigidbody2D myRigidbody;

    protected virtual void Motion(Vector2 direction)
    {
        direction = direction.normalized;
        myRigidbody.velocity = direction * speed;
    }
}
