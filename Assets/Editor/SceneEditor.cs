using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;

public class SceneEditor : EditorWindow
{
    string myString = "Hello World!";

    [MenuItem("Window/Scene Editor")]
    public static void ShowWindow()
    {
        GetWindow<SceneEditor>("Scene Editor");

    }

    void OnGUI()
    {
        GUILayout.Label("Assign Backround to Scenes.", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Name", myString);

        if (GUILayout.Button("Build"))
        {
            Debug.Log("Built!");
        }

    }
}
