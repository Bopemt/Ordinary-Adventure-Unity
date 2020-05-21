using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    [SerializeField] private SimpleFollow myFollow;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float fireDelay;
    [SerializeField] private bool canFire = true;
    private float fireDelaySeconds;

    void Update()
    {
        if (!canFire)
        {
            fireDelaySeconds -= Time.deltaTime;
            if (fireDelaySeconds <= 0)
            {
                canFire = true;
                fireDelaySeconds = fireDelay;
            }
        }
        else if(myFollow.inAttackRange)
        {
            Vector3 tempVector = myFollow.target.transform.position - transform.position;
            GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
            current.GetComponent<Projectile>().Launch(tempVector.normalized);
            canFire = false;
        }
    }
}
