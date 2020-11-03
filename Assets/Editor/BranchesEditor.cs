using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BranchesEditor : EditorWindow
{
    public static string sceneName;

    public static List<Branch> EditorBranches;

    public static void ShowWindow(string _sceneName)
    {
        sceneName = _sceneName;
        GetWindow<BranchesEditor>("Branches Editor").Close();
        GetWindow<BranchesEditor>("Branches Editor").Show();
    }

    private void OnEnable()
    {
        EditorSceneManager.OpenScene("Assets/Resources/Scenes/" + sceneName + ".unity");
        EditorBranches = new List<Branch>();
        EditorBranches = GameObject.Find("Branches").GetComponent<StoryTags>().Branches;
    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        for (int i = 0; i < EditorBranches.Count; i++)
        {
            EditorGUILayout.BeginVertical();
            EditorBranches[i].SceneName = EditorGUILayout.TextField(EditorBranches[i].SceneName);
           
            for (int j = 0; j < EditorBranches[i].Tags.Count; j++)
            {
                EditorBranches[i].Tags[j] = EditorGUILayout.TextField(EditorBranches[i].Tags[j]);
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndHorizontal();

        DrawBuild();

        EditorGUILayout.EndVertical();
    }

    void DrawBuild()
    {
        if (GUILayout.Button("Build"))
        {
            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
        }
    }

    void DrawNextScenes()
    {
        EditorGUILayout.BeginHorizontal();



        EditorGUILayout.EndHorizontal();
    }
}
