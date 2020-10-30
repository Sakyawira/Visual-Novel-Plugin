using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ScreenPlayEditor : EditorWindow
{
    // public UnityEngine. enumEditor = 
    public static List<Emotion> curentEmotion;

    // Scripting System
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
        curentEmotion = new List<Emotion>();

        SceneDialogueLines = GameObject.Find("Character").GetComponent<Dialogue>().DialogueLines;
        Debug.Log(SceneDialogueLines[0].CharacterName);

        for (int i = 0; i < SceneDialogueLines.Count; i++)
        {
            curentEmotion.Add(SceneDialogueLines[i].CharacterEmotion);
        }
    }

    void OnGUI()
    {
        //curentEmotion.Capacity = SceneDialogueLines.Count;

        for (int i = 0; i < SceneDialogueLines.Count; i++)
        {
            curentEmotion[i] = (Emotion)EditorGUILayout.EnumPopup(curentEmotion[i]/*SceneDialogueLines[i].CharacterEmotion*/);
        }
    }
}
