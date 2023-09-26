using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;
    public static DataManager Instance
    {
        get {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DataManager>();
            }
            return _instance;
        }
    }

    public TextAsset ModelJSON;

    [SerializeField]
    public GameModel Model;

    public void Awake()
    {
        _instance = this;
    }

    public void LoadModelEditor()
    {
        Model = JsonUtility.FromJson<GameModel>(ModelJSON.text);
    }

    public void SaveModelEditor(string path)
    {
        string file = JsonUtility.ToJson(Model);

        File.WriteAllText(path, file);
    }
}

[CustomEditor(typeof(DataManager))]
public class DataManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var myScript = target as DataManager;
        if (GUILayout.Button("Load Model"))
        {
            myScript.LoadModelEditor();
        }
        if (GUILayout.Button("Save Model"))
        {
            myScript.SaveModelEditor(Application.dataPath + "/Resources/GameModel.json");
        }


        DrawDefaultInspector();
    }
}
