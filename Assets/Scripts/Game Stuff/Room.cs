using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Room : MonoBehaviour
{
    [Header("Room name")]
    [SerializeField] protected bool haveName;
    [SerializeField] protected string locationName;
    [SerializeField] protected TextMeshProUGUI textMesh;

    [Header("Camera")]
    [SerializeField] protected GameObject virtualCamera;

    [Header("Objects")]
    [SerializeField] protected GameObject[] respawnObjects;

    protected virtual void Start()
    {
        DespawnObjects();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            RespawnObjects();
            virtualCamera.SetActive(true);
            if (haveName)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCamera.SetActive(false);
            DespawnObjects();
        }
    }

    protected void RespawnObjects()
    {
        foreach(GameObject _object in respawnObjects)
        {
            _object.SetActive(true);
            GenericHealth temp = _object.GetComponentInChildren<GenericHealth>();
            if (temp)
            {
                temp.FullHeal();
            }
            ResetToPosition reset = _object.GetComponent<ResetToPosition>();
            {
                if (reset)
                {
                    reset.ResetPosition();
                }
            }
        }
    }

    protected void DespawnObjects()
    {
        foreach(GameObject _object in respawnObjects)
        {
            _object.SetActive(false);
        }
    }

    protected IEnumerator placeNameCo()
    {
        textMesh.gameObject.SetActive(true);
        textMesh.text = locationName;
        textMesh.CrossFadeAlpha(0, 3.5f, false);
        yield return new WaitForSeconds(4f);
        textMesh.gameObject.SetActive(false);
    }
}
