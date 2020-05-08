using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreColliderFamily : MonoBehaviour
{
    public BoxCollider2D Parent;
    public BoxCollider2D Children;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(Parent, Children);
    }

    private void OnEnable()
    {
        Physics2D.IgnoreCollision(Parent, Children);
    }
}
