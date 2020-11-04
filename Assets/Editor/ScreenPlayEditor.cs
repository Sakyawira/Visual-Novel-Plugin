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
        Choices = GameObject.Find("Character").GetComponent<Dialogue>().Choices;
        // Debug.Log(SceneDialogueLines[0].CharacterName);

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

        DrawDialogue(SceneDialogueLines);

        DrawChoices();

        if (GUILayout.Button("Build"))
        {
            for (int i = 0; i < SceneDialogueLines.Count; i++)
            {
                //Line iLine = SceneDialogueLines[i];
                //iLine.CharacterName = currentName[i];
                //iLine.CharacterEmotion = curentEmotion[i];
                //iLine.talkingText = currentText[i];
                //SceneDialogueLines[i] = iLine;
                EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
            }
            //Debug.Log("Built!");
        }
    }
    //void AddTag(int sceneID)
    //{
    //    if (GUILayout.Button("Add Tag"))
    //    {
    //        if (SceneBranches[sceneID].Tags == null)
    //        {
    //            Debug.Log("was null");
    //            Branch ibranch = new Branch();
    //            ibranch.SceneName = SceneBranches[sceneID].SceneName;
    //            ibranch.Tags = new List<string>();

    //            SceneBranches[sceneID] = ibranch;

    //            SceneBranches[sceneID].Tags.Add("");
    //        }
    //        else
    //        {
    //            //Debug.Log("was not null");
    //            //Branch ibranch = new Branch();
    //            //ibranch.SceneName = SceneBranches[sceneID].SceneName;
    //            //ibranch.Tags = new List<string>();

    //            SceneBranches[sceneID].Tags.Add("");
    //        }
    //        ResetMembers();
    //    }
    //}
    void DrawChoices()
    {
        
        if (Choices.Count != 0)
        {
            for (int i = 0; i < Choices.Count; i++)
            {
                Choice iChoice = Choices[i];

                iChoice.ChoiceText = EditorGUILayout.TextField(Choices[i].ChoiceText);
                iChoice.Tag = EditorGUILayout.TextField(Choices[i].Tag);

                Choices[i] = iChoice;

                DrawDialogue(Choices[i].DialogueBranch);

            }
        }
    }

    void DrawDialogue(List<Line> Lines)
    {
        for (int i = 0; i < Lines.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            Line iLine = Lines[i];

            iLine.CharacterName = EditorGUILayout.TextField(Lines[i].CharacterName/*currentName[i]*/);
            iLine.CharacterEmotion = (Emotion)EditorGUILayout.EnumPopup(Lines[i].CharacterEmotion);
            iLine.talkingText = EditorGUILayout.TextField(Lines[i].talkingText);

            Lines[i] = iLine;

            if (GUILayout.Button("Delete Line"))
            {
                Lines.Remove(Lines[i]);
            }

            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add Line"))
        {
            Lines.Add(new Line());
            ResetMembers();
        }
    }
}


