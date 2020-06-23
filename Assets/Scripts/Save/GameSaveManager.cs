using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaveManager : MonoBehaviour
{
    public List<ScriptableObject> objects = new List<ScriptableObject>();

    [Header("Player Stuff")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private VectorValue playerPosition;
    [SerializeField] private StringValue playerScene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F4)) { SceneManager.LoadScene(playerScene.value); }
        if (Input.GetKeyDown(KeyCode.F5)) { SaveGame(); SaveGame(); }
        if (Input.GetKeyDown(KeyCode.F6)) { LoadGame(); }
    }

    private void OnEnable()
    {
        //LoadGame();
    }

    private void OnDisable()
    {
        //SaveGame();
    }

    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/game_save");
    }

    public void SaveGame()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (!IsSaveFile())
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
            }
            for (int i = 0; i < objects.Count; i++)
            {
                FileStream file = File.Create(Application.persistentDataPath + "/game_save" +
                    string.Format("/{0}.sof", i));
                BinaryFormatter bf = new BinaryFormatter();
                var json = JsonUtility.ToJson(objects[i]);
                bf.Serialize(file, json);
                file.Close();
            }
            playerPosition.value = playerTransform.position;
            playerScene.value = SceneManager.GetActiveScene().name;
            Debug.Log("Success");
        }
    }

    public void LoadGame()
    {
        if (IsSaveFile())
        {
            LoadSave();
            SceneManager.LoadScene(playerScene.value);
        }
    }

    public void LoadSave()
    {
        if (IsSaveFile())
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (File.Exists(Application.persistentDataPath + "/game_save" +
                    string.Format("/{0}.sof", i)))
                {
                    FileStream file = File.Open(Application.persistentDataPath + "/game_save" +
                        string.Format("/{0}.sof", i), FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),
                        objects[i]);
                    file.Close();
                }
            }
        }
    }

    public void ResetScriptables()
    {
        foreach (ScriptableObject sObject in objects)
        {
            switch (sObject)
            {
                case BoolValue btmp:
                    btmp.value = btmp.defaultValue;
                    break;
                case FloatValue ftmp:
                    ftmp.value = ftmp.defaultValue;
                    ftmp.maxValue = ftmp.defaultValue;
                    break;
                case VectorValue vtmp:
                    vtmp.value = vtmp.defaultValue;
                    break;
                case PlayerInventory inv:
                    foreach (InventoryItem item in inv.myInventory)
                    {
                        if (item.price != -1)
                        {
                            item.numberHeld = 0;
                        }
                    }
                    inv.Reset();
                    break;
                case ItemValue wv:
                    wv.value = wv.defaultValue;
                    break;
                case QuestsList ql:
                    ql.questList.Clear();
                    break;
                case QuestBoardList qbl:
                    foreach (Quest quest in qbl.allQuests)
                    {
                        quest.inJournal = false;
                        quest.isActive = false;
                        quest.isComplete = false;
                        quest.currentAmount = 0;
                    }
                    qbl.ResetQuestBoard();
                    break;
                case QuestValue qv:
                    qv.value = qv.defaultValue;
                    break;
                case ShopInventory shopInv:
                    shopInv.ResetShopInventory();
                    break;
                case PlayerPocketInventory ppi:
                    ppi.Reset();
                    break;
                default:
                    break;
            }
        }
        for (int i = 0; i < objects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + "/game_save" +
                string.Format("/{0}.sof", i)))
            {
                File.Delete(Application.persistentDataPath + "/game_save" +
                    string.Format("/{0}.sof", i));
            }
        }
        if (Directory.Exists(Application.persistentDataPath + "/game_save"))
        {
            Directory.Delete(Application.persistentDataPath + "/game_save");
        }
    }
}
