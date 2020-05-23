using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericLayerCheck : MonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected SpriteRenderer mySprite;
    [SerializeField] protected int defaultOrder;

    protected void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        defaultOrder = mySprite.sortingOrder;
        if (!mySprite)
        {
            mySprite = GetComponent<SpriteRenderer>();
        }
    }

    protected void CheckLayer()
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
