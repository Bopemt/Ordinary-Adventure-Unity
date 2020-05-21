using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLayerCheck : GenericLayerCheck
{
    [SerializeField] private float checkRadius;

    private void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= checkRadius)
        {
            CheckLayer();
        }
    }
}
