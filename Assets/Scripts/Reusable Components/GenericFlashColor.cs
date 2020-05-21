using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericFlashColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer mySprite;
    [SerializeField] private Color flashColor;
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private float flashDelay;
    [SerializeField] private GameObject kinematicBody;
    [SerializeField] private GameObject healthObject;

    private bool isFlashing = false;

    public void StartFlash()
    {
        if (!isFlashing)
        {
            StartCoroutine(FlashCo());
        }
    }

    public IEnumerator FlashCo()
    {
        isFlashing = true;
        transform.parent.gameObject.layer = 15;
        kinematicBody.layer = 15;
        healthObject.layer = 15;
        for (int i = 0; i < numberOfFlashes; i++)
        {
            if (mySprite)
            {
                mySprite.color = flashColor;
                yield return new WaitForSeconds(flashDelay);
                mySprite.color = Color.white;
                yield return new WaitForSeconds(flashDelay);
            }
        }
        isFlashing = false;
        transform.parent.gameObject.layer = 12;
        kinematicBody.layer = 12;
        healthObject.layer = 12;
    }
}
