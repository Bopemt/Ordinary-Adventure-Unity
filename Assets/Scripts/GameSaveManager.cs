using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaveManager : MonoBehaviour
{
    public List<ScriptableObject> objects = new List<ScriptableObject>();

    void Update()
    {
        if (Input.GetKey(KeyCode.F4)) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
        if (Input.GetKey(KeyCode.F5)) { SaveScriptables(); }
        if (Input.GetKey(KeyCode.F6)) { ResetScriptables(); }
    }

    private void OnEnable()
    {
        LoadScriptables();
    }

    private void OnDisable()
    {
        SaveScriptables();
    }

    public void ResetScriptables()
    {
        for(int i = 0; i< objects.Count; i++)
        {
            foreach (ScriptableObject sObject in objects)
            {
                switch (sObject)
                {
                    case BoolValue btmp:
                        btmp.RuntimeValue = btmp.initialValue;
                        break;
                    case FloatValue ftmp:
                        ftmp.RuntimeValue = ftmp.initialValue;
                        break;
                    case Inventory itmp:
                        itmp.coins = 0;
                        itmp.items.Clear();
                        itmp.numberOfKeys = 0;
                        break;
                    default:
                        break;
                }
            }

            if (File.Exists(Application.persistentDataPath +
                string.Format("/{0}.dat", i)))
            {
                File.Delete(Application.persistentDataPath +
                    string.Format("/{0}.dat", i));
            }
        }
    }

    public void SaveScriptables()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath +
                string.Format("/{0}.dat", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(objects[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptables()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (File.Exists(Application.persistentDataPath +
                string.Format("/{0}.dat", i)))
            {
                FileStream file = File.Open(Application.persistentDataPath +
                    string.Format("/{0}.dat", i), FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file),
                    objects[i]);
                file.Close();
            }
        }
    }

    //public void SaveSctiptables()
    //{
    //    for (int i = 0; i < objects.Count; i++)
    //    {
    //        FileStream file = File.Create(Application.persistentDataPath +
    //            "game.dt");
    //        BinaryFormatter binary = new BinaryFormatter();
    //        binary.Serialize(file, objects[i]);
    //        file.Close();
    //    }
    //}

    //public void LoadScriptables()
    //{
    //    if (File.Exists(Application.persistentDataPath +
    //        "/game.dt"))
    //    {
    //        FileStream file = File.Open(Application.persistentDataPath +
    //            "/game.dt", FileMode.Open);
    //        BinaryFormatter binary = new BinaryFormatter();
    //        //JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file),
    //        //    objects[i]);
    //        objects = (List<ScriptableObject>)binary.Deserialize(file);
    //        file.Close();
    //    }

    //}
}
