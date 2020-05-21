using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] private GameObject pausePanel;
    public string mainMenu;

    [SerializeField] private GenericStateMachine playerState;

    void Start()
    {
        isPaused = false;
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Pause") && playerState.myState != GenericState.inventory && (playerState.myState == GenericState.idle 
            || playerState.myState == GenericState.walk || playerState.myState == GenericState.pause))
        {
            ChangePause();
        }
    }

    public void ChangePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            playerState.myState = GenericState.pause;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            playerState.myState = GenericState.idle;
        }
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}
