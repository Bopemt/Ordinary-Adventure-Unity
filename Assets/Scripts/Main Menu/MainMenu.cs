using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Image point;
    [SerializeField] private Button continueButton;
    [SerializeField] private GameSaveManager saveManager;
    [SerializeField] private StringValue savedSceneName;

    private void Start()
    {
        continueButton.interactable = saveManager.IsSaveFile();
    }

    public void SelectedButtonPoint(Transform buttonTransform)
    {
        point.transform.position = new Vector3(point.transform.position.x, 
            buttonTransform.position.y, point.transform.position.z);
    }

    public void NewGameButton()
    {
        saveManager.ResetScriptables();
        SceneManager.LoadScene("SampleScene");
        saveManager.SaveGame();
    }

    public void ContinueButton()
    {
        saveManager.LoadGame();
        SceneManager.LoadScene(savedSceneName.value);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
