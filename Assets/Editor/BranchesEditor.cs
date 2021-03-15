/***********************
  File Name   :   BranchesEditor.cs
  Description :   define a new editor window where user can edit the different branches a scene can go to, and the conditions to go to that branch
  Author/s    :   Sakyawira Nanda Ruslim
  Mail        :   Sakyawira@gmail.com
********************/
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
            Branch iBranch = new Branch();
            iBranch.Tags = new List<string>();

            for (int j = 0; j < SceneBranches[i].Tags.Count; j++)
            {
                iBranch.Tags.Add(SceneBranches[i].Tags[j]);
            }
            iBranch.SceneName = SceneBranches[i].SceneName;
            EditorBranches.Add(iBranch);
            SceneNames.Add(SceneBranches[i].SceneName);
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

                EditorGUILayout.BeginHorizontal();

                    string iSceneName = EditorGUILayout.TextField(EditorBranches[i].SceneName);
                    Branch IBran = EditorBranches[i];
                    IBran.SceneName = iSceneName;
                    EditorBranches[i] = IBran;

                   

                EditorGUILayout.EndHorizontal();

                if (EditorBranches[i].Tags != null)
                {
                    for (int j = 0; j < EditorBranches[i].Tags.Count; j++)
                    {
                        EditorGUILayout.BeginHorizontal();
                        string iTagName =  EditorGUILayout.TextField(EditorBranches[i].Tags[j]);

                        EditorBranches[i].Tags[j] = iTagName;
                        DeleteTag(i, j);
                        EditorGUILayout.EndHorizontal();
                    }
                }
                AddTag(i);

            DeleteBranch(i);
            EditorGUILayout.EndVertical();
        }
       
        AddBranch();
        EditorGUILayout.EndHorizontal();

        DrawBuild();

        EditorGUILayout.EndVertical();
    }

    void DrawBuild()
    {
        if (GUILayout.Button("Build"))
        {
            SceneBranches.Clear();
            for (int i = 0; i < EditorBranches.Count; i++)
            {
                SceneBranches.Add(EditorBranches[i]);
            }
            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
        }
    }

    void AddBranch()
    {
        if (GUILayout.Button("Add Branch"))
        {
            Branch iBranch = new Branch();
            iBranch.SceneName = "";
            iBranch.Tags = new List<string>();
            EditorBranches.Add(iBranch);
        }
    }

    void DeleteBranch(int branchID)
    {
        if (GUILayout.Button("Delete Branch"))
        {
            EditorBranches.Remove(EditorBranches[branchID]);
        }
    }

    void DeleteTag(int sceneID, int tagID)
    {
        if (GUILayout.Button("Delete Tag"))
        {
            if (EditorBranches[sceneID].Tags == null)
            {
               
            }
            else
            {
                EditorBranches[sceneID].Tags.Remove(EditorBranches[sceneID].Tags[tagID]);
            }
        }
    }

    void AddTag(int sceneID)
    {
        if (GUILayout.Button("Add Tag"))
        {
           if (EditorBranches[sceneID].Tags == null)
            {
                Debug.Log("was null");
                Branch ibranch = EditorBranches[sceneID];
                ibranch.Tags = new List<string>();

                EditorBranches[sceneID] = ibranch;

                EditorBranches[sceneID].Tags.Add("");
            }
            else
            {
                EditorBranches[sceneID].Tags.Add("");
            }
        }
    }

    void DrawNextScenes()
    {
        EditorGUILayout.BeginHorizontal();



        EditorGUILayout.EndHorizontal();
    }
}
