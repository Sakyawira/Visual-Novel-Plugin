using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    public int i_UnlockedLevels;
    public int i_CurrentLevel;
    public List<string> tags;

    public GameData(PlayerTags playerTags)
    {
        i_CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        i_UnlockedLevels = SceneManager.GetActiveScene().buildIndex;
        if (i_UnlockedLevels == 0)
        {
            i_UnlockedLevels = 1;
        }
        tags = playerTags.Tags;
    }
}

public class PlayerTags : MonoBehaviour
{
    public List<string> Tags;

    private void Awake()
    {
        GameObject[] staticObject = GameObject.FindGameObjectsWithTag("Player");
        if (staticObject.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        GameData data = SaveSystem.LoadData();
        if (data != null)
        {
            Tags.Clear();
            Tags = data.tags;
        }
    }

    public void AddTag(string newTag)
    {
        if (Tags.Contains(newTag) == false && newTag != "")
        {
            Tags.Add(newTag);
            SaveSystem.SaveData(this);
        }
    }
}