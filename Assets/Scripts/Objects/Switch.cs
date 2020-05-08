using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool isActive;
    public BoolValue storedValue;
    public Sprite activeSprite;
    private SpriteRenderer mySprite;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        isActive = storedValue.RuntimeValue;
        if (isActive)
        {
            ActivateSwitch();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            ActivateSwitch();
        }
    }

    public void ActivateSwitch()
    {
        isActive = true;
        storedValue.RuntimeValue = isActive;
        mySprite.sprite = activeSprite;
    }
}
