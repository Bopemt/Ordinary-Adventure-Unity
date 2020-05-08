using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    //public static GameSaveManager gameSave;
    public List<ScriptableObject> objects = new List<ScriptableObject>();

    //private void Awake()
    //{
    //    if(gameSave == null)
    //    {
    //        gameSave = this;
    //    }
    //    else
    //    {
    //        Destroy(this);
    //    }
    //    DontDestroyOnLoad(this.gameObject);
    //}

    private void OnEnable()
    {
        LoadScriptables();
    }

    private void OnDisable()
    {
        SaveSctiptables();
    }

    public void SaveSctiptables()
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
