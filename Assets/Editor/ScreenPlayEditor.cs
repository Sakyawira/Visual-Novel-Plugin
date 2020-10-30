using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ScreenPlayEditor : EditorWindow
{
    // Temporary Objects for Editor
    public static List<Emotion> curentEmotion;
    public static List<string> currentName;
    public static List<string> currentText;

    // References to Objects in Level
    public static List<Line> SceneDialogueLines;
    public static List<Choice> Choices;

    public static string sceneName;

    //[MenuItem("Window/ScreenPlay Editor")]
    public static void ShowWindow(string _sceneName)
    {
        sceneName = _sceneName;
        GetWindow<ScreenPlayEditor>("ScreenPlay Editor").Close();
        GetWindow<ScreenPlayEditor>("ScreenPlay Editor").Show();
    }

    private void OnEnable()
    {
        EditorSceneManager.OpenScene("Assets/Resources/Scenes/" + sceneName + ".unity");

        SceneDialogueLines = new List<Line>();
        SceneDialogueLines = GameObject.Find("Character").GetComponent<Dialogue>().DialogueLines;
        Debug.Log(SceneDialogueLines[0].CharacterName);

        ResetMembers();
    }

    void ResetMembers()
    {
        curentEmotion = new List<Emotion>();
        currentName = new List<string>();
        currentText = new List<string>();

        for (int i = 0; i < SceneDialogueLines.Count; i++)
        {
            curentEmotion.Add(SceneDialogueLines[i].CharacterEmotion);
            currentName.Add(SceneDialogueLines[i].CharacterName);
            currentText.Add(SceneDialogueLines[i].talkingText);
        }
    }

    void OnGUI()
    {
        //curentEmotion.Capacity = SceneDialogueLines.Count;

        for (int i = 0; i < SceneDialogueLines.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            currentName[i] = EditorGUILayout.TextField(currentName[i]);
            curentEmotion[i] = (Emotion)EditorGUILayout.EnumPopup(curentEmotion[i]/*SceneDialogueLines[i].CharacterEmotion*/);
            currentText[i] = EditorGUILayout.TextField(currentText[i]);
            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add Line"))
        {
            SceneDialogueLines.Add(new Line());
            ResetMembers();
        }

            if (GUILayout.Button("Build"))
        {
            for (int i = 0; i < SceneDialogueLines.Count; i++)
            {
                Line iLine = SceneDialogueLines[i];
                iLine.CharacterName = currentName[i];
                iLine.CharacterEmotion = curentEmotion[i];
                iLine.talkingText = currentText[i];
                SceneDialogueLines[i] = iLine;
                EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
            }
            Debug.Log("Built!");
        }
    }
}
