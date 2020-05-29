using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaveManager : MonoBehaviour
{
    //public static GameSaveManager instance;
    public List<ScriptableObject> objects = new List<ScriptableObject>();

    void Update()
    {
        if (Input.GetKey(KeyCode.F4)) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
        if (Input.GetKey(KeyCode.F5)) { SaveGame(); }
        if (Input.GetKey(KeyCode.F6)) { ResetScriptables(); SceneManager.LoadScene("SampleScene"); }
    }

    private void OnEnable()
    {
        LoadGame();
    }

    private void OnDisable()
    {
        SaveGame();
    }

    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/game_save");
    }

    public void SaveGame()
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
        }
        for (int i = 0; i < objects.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath + "/game_save" +
                string.Format("/{0}.txt", i));
            BinaryFormatter bf = new BinaryFormatter();
            var json = JsonUtility.ToJson(objects[i]);
            bf.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadGame()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath + "/game_save" +
                string.Format("/{0}.txt", i)))
            {
                FileStream file = File.Open(Application.persistentDataPath +
                    string.Format("/{0}.txt", i), FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),
                    objects[i]);
                file.Close();
            }
        }
    }

    public void ResetScriptables()
    {
        for (int i = 0; i < objects.Count; i++)
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
                    case PlayerInventory inv:
                        inv.myInventory.Clear();
                        break;
                    case ItemValue wv:
                        wv.value = wv.defaultValue;
                        break;
                    default:
                        break;
                }
            }

            if (File.Exists(Application.persistentDataPath +
                string.Format("/{0}.txt", i)))
            {
                File.Delete(Application.persistentDataPath +
                    string.Format("/{0}.txt", i));
            }
        }
    }

    //public void SaveSctiptables()
    //{
    //    for (int i = 0; i < objects.Count; i++)
    //    {
    //        FileStream file = File.Create(Application.persistentDataPath +
    //            "game.dt");
    //        BinaryFormatter bf = new BinaryFormatter();
    //        bf.Serialize(file, objects[i]);
    //        file.Close();
    //    }
    //}

    //public void LoadGame()
    //{
    //    if (File.Exists(Application.persistentDataPath +
    //        "/game.dt"))
    //    {
    //        FileStream file = File.Open(Application.persistentDataPath +
    //            "/game.dt", FileMode.Open);
    //        BinaryFormatter bf = new BinaryFormatter();
    //        //JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),
    //        //    objects[i]);
    //        objects = (List<ScriptableObject>)bf.Deserialize(file);
    //        file.Close();
    //    }

    //}
}
