using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public float lifetime;
    private float lifetimeSeconds;

    void Start()
    {
        lifetimeSeconds = lifetime;
    }

    void Update()
    {
        lifetimeSeconds -= Time.deltaTime;
        if (lifetimeSeconds <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Setup(Vector3 direction, Vector3 position)
    {
        transform.rotation = Quaternion.Euler(direction);
        transform.position = position;
    }
}
