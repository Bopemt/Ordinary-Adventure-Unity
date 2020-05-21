using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    //[SerializeField] private Vector2 direction;
    [SerializeField] private Rigidbody2D myRigidbody;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 initialVelocity)
    {
        myRigidbody.velocity = initialVelocity * moveSpeed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}
