using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameObject storyTags;

    public void Start()
    {
        storyTags = GameObject.Find("Branches");
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Continue()
    {
        string NextLevel = storyTags.GetComponent<StoryTags>().GetNextLevel();
        SceneManager.LoadScene(NextLevel);
    }
}