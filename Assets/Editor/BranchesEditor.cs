using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BranchesEditor : EditorWindow
{
    public static string sceneName;

    private static List<Branch> EditorBranches;
    public static List<Branch> SceneBranches;

    public static List<string> SceneNames;

    void ResetMembers()
    {
        EditorBranches = new List<Branch>();
        SceneNames = new List<string>();

        for (int i = 0; i < SceneBranches.Count; i++)
        {
            Branch iBranch = new Branch()/*SceneBranches[i]*/;
            iBranch.Tags = new List<string>();

            for (int j = 0; j < SceneBranches[i].Tags.Count; j++)
            {
                iBranch.Tags.Add(SceneBranches[i].Tags[j]);
            }

            // //EditorBranches[i].SceneName = SceneBranches[i].SceneName;
            iBranch.SceneName = SceneBranches[i].SceneName;
            //iBranch.Tags = SceneBranches[i].Tags;
           
            EditorBranches.Add(iBranch);

            SceneNames.Add(SceneBranches[i].SceneName);
            //EditorBranches[i].SceneName = SceneBranches[i].SceneName;
            //EditorBranches[i].Tags = new List<string>();


        }
    }

    public static void ShowWindow(string _sceneName)
    {
        sceneName = _sceneName;
        GetWindow<BranchesEditor>("Branches Editor").Close();
        GetWindow<BranchesEditor>("Branches Editor").Show();
    }

    private void OnEnable()
    {
        EditorSceneManager.OpenScene("Assets/Resources/Scenes/" + sceneName + ".unity");
        SceneBranches = GameObject.Find("Branches").GetComponent<StoryTags>().Branches;
        ResetMembers();
    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        for (int i = 0; i < EditorBranches.Count; i++)
        {
            EditorGUILayout.BeginVertical();

            //  SceneNames[i] = EditorGUILayout.TextField(SceneNames[i]);
            string iSceneName = EditorGUILayout.TextField(EditorBranches[i].SceneName);
            Branch IBran = EditorBranches[i];
            IBran.SceneName = iSceneName;

            EditorBranches[i] = IBran;

            if (EditorBranches[i].Tags != null)
            {
                for (int j = 0; j < EditorBranches[i].Tags.Count; j++)
                {
                    /*EditorBranches[i].Tags[j] = */
                      EditorGUILayout.TextField(EditorBranches[i].Tags[j]);
                }
            }
            AddTag(i);
            EditorGUILayout.EndVertical();
        }
        AddScene();
        EditorGUILayout.EndHorizontal();

        DrawBuild();

        EditorGUILayout.EndVertical();
    }

    void DrawBuild()
    {
        if (GUILayout.Button("Build"))
        {
            for (int i = 0; i < SceneBranches.Count; i++)
            {
                SceneBranches[i] = EditorBranches[i];
            }
            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
        }
    }

    void AddScene()
    {
        if (GUILayout.Button("Add Scene"))
        {
            Branch iBranch = new Branch();
            iBranch.SceneName = "";
            iBranch.Tags = new List<string>();
            //iBranch.Tags.Add("");

            SceneBranches.Add(iBranch);
            //SceneBranches[SceneBranches.Count-1].Tags.Add("");
            ResetMembers();
            //EditorBranches.Add(new Branch());
            //EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
        }
    }

    void AddTag(int sceneID)
    {
        if (GUILayout.Button("Add Tag"))
        {
           if (SceneBranches[sceneID].Tags == null)
            {
                Debug.Log("was null");
                Branch ibranch = new Branch();
                ibranch.SceneName = SceneBranches[sceneID].SceneName;
                ibranch.Tags = new List<string>();

                SceneBranches[sceneID] = ibranch;

                SceneBranches[sceneID].Tags.Add("");
            }
            else
            {
                //Debug.Log("was not null");
                //Branch ibranch = new Branch();
                //ibranch.SceneName = SceneBranches[sceneID].SceneName;
                //ibranch.Tags = new List<string>();

                SceneBranches[sceneID].Tags.Add("");
            }
            ResetMembers();
        }
    }

    void DrawNextScenes()
    {
        EditorGUILayout.BeginHorizontal();



        EditorGUILayout.EndHorizontal();
    }
}
