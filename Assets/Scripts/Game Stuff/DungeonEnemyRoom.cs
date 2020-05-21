using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : Room
{
    [SerializeField] private Door[] doors;

    protected override void Start()
    {
        base.Start();
        OpenDoors();
    }

    public int EnemiesActive()
    {
        int activeEnemies = 0;

        foreach(GameObject _object in respawnObjects)
        {
            if (_object.GetComponent<Rigidbody2D>())
            {
                if (_object.GetComponent<Rigidbody2D>().gameObject.activeInHierarchy)
                {
                    activeEnemies++;
                }
            }
        }
        return activeEnemies;
    }

    public void CheckEnemies()
    {
        if (EnemiesActive() == 1)
        {
            OpenDoors();
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            RespawnObjects();
            virtualCamera.SetActive(true);
            if (haveName)
            {
                StartCoroutine(placeNameCo());
            }
            if(EnemiesActive() == 0) { return; }
            Invoke("CloseDoors", 0.8f);
        }
    }

    public void CloseDoors()
    {
        for(int i = 0; i < doors.Length; i++)
        {
            doors[i].Close();
        }
    }

    public void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Open();
        }
    }
}
