using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverworldRoomWithName : Room
{
    public string locationName;
    public GameObject textBox;
    public TextMeshProUGUI textMesh;
    
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);
            }

            for (int i = 0; i < breakables.Length; i++)
            {
                ChangeActivation(breakables[i], true);
            }
            virtualCamera.SetActive(true);
            StartCoroutine(placeNameCo());
        }
    }

    private IEnumerator placeNameCo()
    {
        textBox.SetActive(true);
        textMesh.text = locationName;
        textMesh.CrossFadeAlpha(0, 3.5f, false);
        yield return new WaitForSeconds(4f);
        textBox.SetActive(false);
    }
}
