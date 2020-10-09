using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

public class SceneEditor : EditorWindow
{
    // Library of scenes we have. 
    static List<SceneAsset> scenes;

    List<UnityEngine.Object> spritesField;

    //Sprite sprite;

   // public UnityEngine.Object source;
   // public UnityEngine.Object sprite;

    [MenuItem("Window/Scene Editor")]
    public static void ShowWindow()
    {
        GetWindow<SceneEditor>("Scene Editor");

    }

    private void OnEnable()
    {
        // V loading all the fill tiles
        scenes = new List<SceneAsset>(Resources.LoadAll<SceneAsset>("Scenes"));
        spritesField = new List<UnityEngine.Object>();
       // sprite = 


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
            UnityEngine.Object sprite = new Object();
            spritesField.Add(sprite);

            spritesField[i] = EditorGUILayout.ObjectField(scenes[i].name, spritesField[i], typeof(Sprite), true);
        }

        if (GUILayout.Button("Build"))
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                //Scene a = scenes[i];
                //a.FindObjectsOfType<Image>();
                EditorSceneManager.OpenScene("Assets/Resources/Scenes/" + scenes[i].name + ".unity");
                //FindObjectsOfType<Image>()
                UnityEngine.UI.Image myimage = GameObject.Find("BackgroundImage").GetComponent<UnityEngine.UI.Image>();
                Debug.Log(myimage.name);
                myimage.sprite = (Sprite)spritesField[i];
                EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
            }
                Debug.Log("Built!");
        }

    }
}
