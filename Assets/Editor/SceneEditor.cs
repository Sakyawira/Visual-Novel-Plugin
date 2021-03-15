/***********************
  File Name   :   BranchesEditor.cs
  Description :   define a new editor window where user can change the background of image of each scene and entry point to all the other editors in this toolset
  Author/s    :   Sakyawira Nanda Ruslim
  Mail        :   Sakyawira@gmail.com
********************/
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
    // Library of scenes we have. 
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
            spritesField[i] = (Sprite)EditorGUILayout.ObjectField(spritesField[i], typeof(Sprite), true, GUILayout.Width(50), GUILayout.Height(50));
            EditorGUILayout.BeginVertical();

            if (GUILayout.Button("Edit ScreenPlay"))
            {
                ScreenPlayEditor.ShowWindow(scenes[i].name);
            }

            if (GUILayout.Button("Edit Branches"))
            {
                BranchesEditor.ShowWindow(scenes[i].name);
            }

            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();

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
