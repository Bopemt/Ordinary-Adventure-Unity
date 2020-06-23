using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool isActive;
    private bool onSwitchCheck = false;
    [SerializeField] private BoolValue storedValue;
    [SerializeField] private Sprite activeSprite;
    private SpriteRenderer mySprite;
    [SerializeField] private GenericStateMachine myState;

    [Header("Notification Text Stuff")]
    [SerializeField] private bool notification;
    [SerializeField] private string text;
    [SerializeField] private string speakerName;
    [SerializeField] private StringValue stringText;
    [SerializeField] private StringValue stringName;

    [Header("Dialog Stuff")]
    [SerializeField] private SignalCore dialogSignal;

    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        isActive = storedValue.value;
        if (isActive)
        {
            ActivateSwitch();
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Interact") && myState.myState == GenericState.interact && onSwitchCheck)
        {
            DisableContents();
            onSwitchCheck = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger && !isActive)
        {
            ActivateSwitch();
            if (notification)
            {
                onSwitchCheck = true;
                DisplayContents();
            }
        }
    }

    void ActivateSwitch()
    {
        isActive = true;
        storedValue.value = isActive;
        mySprite.sprite = activeSprite;
    }

    void DisplayContents()
    {
        stringName.value = speakerName;
        stringText.value = text;
        dialogSignal.Raise();
        myState.ChangeState(GenericState.interact);
        Time.timeScale = 0.000001f;
    }

    void DisableContents()
    {
        myState.ChangeState(GenericState.idle);
        dialogSignal.Raise();
        Time.timeScale = 1;
    }
}
