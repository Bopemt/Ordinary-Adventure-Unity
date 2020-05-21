using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public Switch statueSwitch;
    public bool isActive;
    public BoolValue storedValue;
    public Sprite activeSprite;
    private SpriteRenderer mySprite;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        isActive = storedValue.value;
        if (isActive)
        {
            ActivateStatue();
        }
    }

    void Update()
    {
        if (statueSwitch.isActive && !isActive)
        {
            ActivateStatue();
        }
    }

    public void ActivateStatue()
    {
        isActive = true;
        storedValue.value = isActive;
        mySprite.sprite = activeSprite;
    }
}
