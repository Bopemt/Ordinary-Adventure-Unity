using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestKill : Quest
{
    public GameObject[] enemies;

    public int EnemiesActive()
    {
        int activeEnemies = 0;

        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<Rigidbody2D>().gameObject.activeInHierarchy)
            {
                activeEnemies++;
            }
        }

        return activeEnemies;
    }

    public void CheckEnemies()
    {
        if (EnemiesActive() == 1)
        {
            questSignal.Raise();
        }
    }
}
