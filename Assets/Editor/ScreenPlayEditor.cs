using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScreenPlayEditor : EditorWindow
{
    // public UnityEngine. enumEditor = 
    public Emotion curentEmotion;

    //[MenuItem("Window/ScreenPlay Editor")]
    public static void ShowWindow()
    {
        GetWindow<ScreenPlayEditor>("ScreenPlay Editor");
    }

    void OnGUI()
    {
        curentEmotion = (Emotion)EditorGUILayout.EnumPopup(curentEmotion);
    }
}
