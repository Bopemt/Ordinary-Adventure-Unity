using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetToPosition : MonoBehaviour
{
    [SerializeField] private Vector2 resetPosition;

    //private void Start()
    //{
    //    resetPosition = transform.position;
    //}

    private void Awake()
    {
        resetPosition = transform.position;
    }

    public void ResetPosition()
    {
        transform.position = resetPosition;
    }
}
