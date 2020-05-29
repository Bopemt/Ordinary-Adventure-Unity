using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class InventorySaver : MonoBehaviour
{
    [SerializeField] private PlayerInventory myInventory;

    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.F4)) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    //    if (Input.GetKey(KeyCode.F5)) { SaveGame(); }
    //    if (Input.GetKey(KeyCode.F6)) { ResetScriptables(); SceneManager.LoadScene("SampleScene"); }
    //}

    private void OnEnable()
    {
        myInventory.myInventory.Clear();
        LoadScriptables();
    }

    private void OnDisable()
    {
        SaveScriptables();
    }

    public void ResetScriptables()
    {
        //for (int i = 0; i < myInventory.myInventory.Count; i++)
        //{
        //    foreach (ScriptableObject sObject in myInventory.myInventory)
        //    {
        //        switch (sObject)
        //        {
        //            case BoolValue btmp:
        //                btmp.value = btmp.defaultValue;
        //                break;
        //            case FloatValue ftmp:
        //                ftmp.value = ftmp.defaultValue;
        //                break;
        //            case Inventory itmp:
        //                itmp.coins = 0;
        //                itmp.items.Clear();
        //                itmp.numberOfKeys = 0;
        //                break;
        //            default:
        //                break;
        //        }
        //    }

        //    if (File.Exists(Application.persistentDataPath +
        //        string.Format("/{0}.dat", i)))
        //    {
        //        File.Delete(Application.persistentDataPath +
        //            string.Format("/{0}.dat", i));
        //    }
        //}
        int i = 0;
        while (File.Exists(Application.persistentDataPath +
                string.Format("/{0}.inv", i)))
        {
            File.Delete(Application.persistentDataPath +
                string.Format("/{0}.inv", i));
            i++;
        }
    }

    public void SaveScriptables()
    {
        ResetScriptables();
        for (int i = 0; i < myInventory.myInventory.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath +
                string.Format("/{0}.inv", i));
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(myInventory.myInventory[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptables()
    {
        int i = 0;
        while (File.Exists(Application.persistentDataPath +
            string.Format("/{0}.inv", i)))
        {
            var temp = ScriptableObject.CreateInstance<InventoryItem>();
            FileStream file = File.Open(Application.persistentDataPath +
                string.Format("/{0}.inv", i), FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter();
            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file),
                temp);
            file.Close();
            myInventory.myInventory.Add(temp);
            i++;
        }
    }
}
