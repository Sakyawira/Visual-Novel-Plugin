using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;

public class SceneEditor : EditorWindow
{
   // string myString = "Hello World!";

    // library of tiles we have. 
    static List<SceneAsset> scenes;

    List<UnityEngine.Object> spritesField;

   // public UnityEngine.Object source;
    public UnityEngine.Object sprite;

    [MenuItem("Window/Scene Editor")]
    public static void ShowWindow()
    {
        GetWindow<SceneEditor>("Scene Editor");

    }

    private void OnEnable()
    {
        // V loading all the fill tiles
        scenes = new List<SceneAsset>(Resources.LoadAll<SceneAsset>("Scenes"));

        sprite = new Object();


        //VisualElement root = rootVisualElement;

        //root.styleSheets.Add(Resources.Load<StyleSheet>("newTool_Style"));
        //VisualTreeAsset newVisualTree = Resources.Load<VisualTreeAsset>("newTool_Main");

        //newVisualTree.CloneTree(root);

        //var toolButtons = root.Query<Button>();

        //toolButtons.ForEach(SetupButton);
    }

    void OnGUI()
    {
        GUILayout.Label("Assign Backround to Scenes.", EditorStyles.boldLabel);
       // myString = EditorGUILayout.TextField("Name", myString);

        Debug.Log(scenes.Count);

        for (int i = 0; i < scenes.Count; i++)
        {
            Debug.Log(i);
            // objTile newItem = new objTile();
            //  newItem.prefab = tileObjects[i];
            // newItem.enabled = false;
            // tiles.Add(newItem);
            // GUILayout.image
           // source = EditorGUILayout.ObjectField("BG", source, typeof(UnityEngine.Object), true);
            sprite = EditorGUILayout.ObjectField(scenes[i].name, sprite, typeof(Sprite), true);
           // spritesField.Add(sprite);
        }

        if (GUILayout.Button("Build"))
        {
            Debug.Log("Built!");
        }

    }
}
