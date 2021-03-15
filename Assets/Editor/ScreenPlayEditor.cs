/***********************
  File Name   :   ScreenPlayEditor.cs
  Description :   define a new editor window where user can edit the screenplay of a scene (consisting of dialogues)
  Author/s    :   Sakyawira Nanda Ruslim
  Mail        :   Sakyawira@gmail.com
********************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ScreenPlayEditor : EditorWindow
{
    // Temporary Objects for Editor
    public static List<Line> EditorDialogueLines;
    public static List<Choice> EditorChoices;
    public static CharacterDatabase EditorDB;

    // References to Objects in Level
    public static List<Line> SceneDialogueLines;
    public static List<Choice> SceneChoices;
    public static CharacterDatabase SceneDB;

    public static string sceneName;

    public static bool hasChoice = false;

    public static void ShowWindow(string _sceneName)
    {
        sceneName = _sceneName;
        GetWindow<ScreenPlayEditor>("ScreenPlay Editor").Close();
        GetWindow<ScreenPlayEditor>("ScreenPlay Editor").Show();
    }

    private void OnEnable()
    {
        EditorSceneManager.OpenScene("Assets/Resources/Scenes/" + sceneName + ".unity");

        SceneDialogueLines = GameObject.Find("Character").GetComponent<Dialogue>().DialogueLines;
        SceneChoices = GameObject.Find("Character").GetComponent<Dialogue>().Choices;
        SceneDB = GameObject.Find("Character").GetComponent<Dialogue>().CharacterDB;

        EditorDialogueLines = new List<Line>();
        EditorChoices = new List<Choice>();

        ResetMembers();
    }

    void ResetMembers()
    {
        EditorDB = SceneDB;

        if (SceneChoices.Count == 0)
        {
            hasChoice = false;
        }
        else
        {
            hasChoice = true;
        }

        for (int i = 0; i < SceneDialogueLines.Count; i++)
        {
            EditorDialogueLines.Add(SceneDialogueLines[i]);
        }
        for (int i = 0; i < SceneChoices.Count; i++)
        {
            EditorChoices.Add(SceneChoices[i]);
        }
    }

    void OnGUI()
    {
        EditorDB = (CharacterDatabase)EditorGUILayout.ObjectField(EditorDB, typeof(CharacterDatabase), true, GUILayout.MinWidth(150), GUILayout.Height(25));

        DrawDialogue(EditorDialogueLines);

        if (hasChoice = GUILayout.Toggle(hasChoice, "Has Choices ?"))
        {
            if (EditorChoices.Count == 0)
            {
                Choice newChoice = new Choice();
                newChoice.DialogueBranch = new List<Line>();
                EditorChoices.Add(newChoice);

                newChoice = new Choice();
                newChoice.DialogueBranch = new List<Line>();
                EditorChoices.Add(newChoice);
            }
            DrawChoices();
        }
        else
        {
            if (EditorChoices.Count != 0)
            {
                EditorChoices.Clear();
            }
        }

        if (GUILayout.Button("Build"))
        {
            GameObject.Find("Character").GetComponent<Dialogue>().CharacterDB = EditorDB;

            SceneDialogueLines.Clear();
            for (int i = 0; i < EditorDialogueLines.Count; i++)
            {
                SceneDialogueLines.Add(EditorDialogueLines[i]);
            }

            SceneChoices.Clear();
            for (int i = 0; i < EditorChoices.Count; i++)
            {
                SceneChoices.Add(EditorChoices[i]);
            }

            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
        }
    }

    void DrawChoices()
    {    
        if (EditorChoices.Count != 0)
        {
            for (int i = 0; i < EditorChoices.Count; i++)
            {
                Choice iChoice = EditorChoices[i];

                EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Choice Text", GUILayout.MaxWidth(78));
                iChoice.ChoiceText = EditorGUILayout.TextField(EditorChoices[i].ChoiceText);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Given Tag", GUILayout.MaxWidth(78));
                iChoice.Tag = EditorGUILayout.TextField(EditorChoices[i].Tag);
                EditorGUILayout.EndHorizontal();

                EditorChoices[i] = iChoice;

                DrawDialogue(EditorChoices[i].DialogueBranch);
            }
        }
    }

    void DrawDialogue(List<Line> Lines)
    {
        for (int i = 0; i < Lines.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            Line iLine = Lines[i];

            iLine.CharacterName = EditorGUILayout.TextField(Lines[i].CharacterName, GUILayout.MaxWidth(65));
            iLine.CharacterEmotion = (Emotion)EditorGUILayout.EnumPopup(Lines[i].CharacterEmotion, GUILayout.MaxWidth(65));
            iLine.talkingText = EditorGUILayout.TextField(Lines[i].talkingText);

            Lines[i] = iLine;

            if (GUILayout.Button("Delete Line", GUILayout.MaxWidth(130)))
            {
                Lines.Remove(Lines[i]);
            }

            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add Line"))
        {
            Lines.Add(new Line());
        }
    }
}