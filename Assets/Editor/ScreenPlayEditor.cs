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

    // public static List<Emotion> curentEmotion;
    // public static List<string> currentName;
    // public static List<string> currentText;

    // References to Objects in Level
    public static List<Line> SceneDialogueLines;
    public static List<Choice> SceneChoices;
    public static CharacterDatabase SceneDB;

    public static string sceneName;

    public static bool hasChoice = false;

    List<Vector2> scrollPos;

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

        // SceneDialogueLines = new List<Line>();
        SceneDialogueLines = GameObject.Find("Character").GetComponent<Dialogue>().DialogueLines;
        SceneChoices = GameObject.Find("Character").GetComponent<Dialogue>().Choices;
        SceneDB = GameObject.Find("Character").GetComponent<Dialogue>().CharacterDB;

        EditorDialogueLines = new List<Line>();
        EditorChoices = new List<Choice>();

        scrollPos = new List<Vector2>();
        for (int i = 0; i < 3; i++)
        {
            scrollPos.Add(Vector2.zero);
        }

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
           // Choice newChoice = new Choice();
           // newChoice.ChoiceText = SceneChoices[i].ChoiceText;
           // newChoice.Tag = SceneChoices[i].Tag;
           // newChoice.DialogueBranch = new List<Line>();
            EditorChoices.Add(SceneChoices[i]);
        }
        //for (int i = 0; i < EditorChoices.Count; i++)
        //{
        //   for(int j = 0; j < EditorChoices[i].DialogueBranch.Count; j++)
        //    {
        //        Line iLine = new Line();
        //        iLine.CharacterEmotion = SceneChoices[i].DialogueBranch[j].CharacterEmotion;
        //        iLine.CharacterName = SceneChoices[i].DialogueBranch[j].CharacterName;
        //        iLine.CharacterName = SceneChoices[i].DialogueBranch[j].talkingText;
        //        EditorChoices[i].DialogueBranch[j] = iLine;
        //    }
        //}
    }

    void OnGUI()
    {
        //curentEmotion.Capacity = SceneDialogueLines.Count;
        scrollPos[0] = EditorGUILayout.BeginScrollView(scrollPos[0], GUILayout.Height(position.height));
        GUILayout.Label(sceneName, EditorStyles.boldLabel);

        EditorDB = (CharacterDatabase)EditorGUILayout.ObjectField(EditorDB, typeof(CharacterDatabase), true, GUILayout.MinWidth(150), GUILayout.Height(25));

        DrawDialogue(EditorDialogueLines, 0);

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
                //Line iLine = SceneDialogueLines[i];
                //iLine.CharacterName = currentName[i];
                //iLine.CharacterEmotion = curentEmotion[i];
                //iLine.talkingText = currentText[i];
                SceneDialogueLines.Add(EditorDialogueLines[i]);
                
            }

            SceneChoices.Clear();
            for (int i = 0; i < EditorChoices.Count; i++)
            {
                //Line iLine = SceneDialogueLines[i];
                //iLine.CharacterName = currentName[i];
                //iLine.CharacterEmotion = curentEmotion[i];
                //iLine.talkingText = currentText[i];
                SceneChoices.Add(EditorChoices[i]);
            }

            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
            //Debug.Log("Built!");
        }

        EditorGUILayout.EndScrollView();

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

                DrawDialogue(EditorChoices[i].DialogueBranch, i + 1);
            }
        }
    }

    void DrawDialogue(List<Line> Lines, int scrollId)
    {
        //scrollPos[scrollId] = EditorGUILayout.BeginScrollView(scrollPos[scrollId], GUILayout.Height(200));

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
        
        //EditorGUILayout.EndScrollView();

        if (GUILayout.Button("Add Line"))
        {
            Lines.Add(new Line());
           // ResetMembers();
        }

    }
}


