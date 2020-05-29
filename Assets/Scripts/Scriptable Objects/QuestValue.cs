using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Values/Quest Value", fileName = "New Quest Value")]
public class QuestValue : ScriptableObject
{
    public Quest defaultValue;

    public Quest value;

    private void OnEnable()
    {
        //value = defaultValue;
    }

    public void CheckCompleted()
    {
        if(value)
            value.CheckQuest();
    }
}
