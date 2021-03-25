using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

public class SceneEditor : EditorWindow
{
    static List<SceneAsset> scenes;
    List<UnityEngine.Object> spritesField;
    [MenuItem("Window/Scene Editor")]
    public static void ShowWindow()
    {
        GetWindow<SceneEditor>("Scene Editor");
    }

    private void OnEnable()
    {
        // V loading all the fill tiles
        scenes = new List<SceneAsset>(Resources.LoadAll<SceneAsset>("Scenes"));
        spritesField = new List<UnityEngine.Object>();

        // Set the default images
        for (int i = 0; i < scenes.Count; i++)
        {
            EditorSceneManager.OpenScene("Assets/Resources/Scenes/" + scenes[i].name + ".unity");
            UnityEngine.UI.Image myimage = GameObject.Find("BackgroundImage").GetComponent<UnityEngine.UI.Image>();
            spritesField.Add(myimage.sprite);
        }
    }

    void OnGUI()
    {
        GUILayout.Label("Assign Backround to Scenes.", EditorStyles.boldLabel);

        for (int i = 0; i < scenes.Count; i++)
        {
            UnityEngine.Object sprite = new Object();
            EditorGUILayout.BeginVertical();
            GUILayout.Label(scenes[i].name);

            EditorGUILayout.BeginHorizontal();
            spritesField[i] = (Sprite)EditorGUILayout.ObjectField(/*scenes[i].name, */spritesField[i], typeof(Sprite), true, GUILayout.Width(50), GUILayout.Height(50));
            EditorGUILayout.BeginVertical();

            if (GUILayout.Button("Edit ScreenPlay"/*, GUILayout.Height(40)*/))
            {
                ScreenPlayEditor.ShowWindow(scenes[i].name);
            }

            if (GUILayout.Button("Edit Branches"/*, GUILayout.Height(40)*/))
            {
                BranchesEditor.ShowWindow(scenes[i].name);
            }

            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();

            //DrawNextScenes();

            EditorGUILayout.EndVertical();
        }

        if (GUILayout.Button("Build"))
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                EditorSceneManager.OpenScene("Assets/Resources/Scenes/" + scenes[i].name + ".unity");
                UnityEngine.UI.Image myimage = GameObject.Find("BackgroundImage").GetComponent<UnityEngine.UI.Image>();
                myimage.sprite = (Sprite)spritesField[i];
                EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
            }
        }

    }
}
