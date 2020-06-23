using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeathManager : MonoBehaviour
{
    [SerializeField] private GameObject playerDeathNotification;
    [SerializeField] private GameSaveManager saveManager;
    [SerializeField] private Button loadButton;
    [SerializeField] private string mainMenu;

    public void PlayerDie()
    {
        playerDeathNotification.SetActive(true);
        loadButton.interactable = saveManager.IsSaveFile();
    }

    public void LoadButton()
    {
        playerDeathNotification.SetActive(false);
        saveManager.LoadGame();
    }

    public void QuitButton()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }


}
