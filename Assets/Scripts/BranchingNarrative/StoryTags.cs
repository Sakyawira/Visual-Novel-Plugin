/***********************
  File Name   :   StoryTags.cs
  Description :   define a system to create branching storyline and conditions to go to each of those branches
  Author/s    :   Sakyawira Nanda Ruslim
  Mail        :   Sakyawira@gmail.com
********************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct Branch
{
    public List<string> Tags;
    public string SceneName;
}

public class StoryTags : MonoBehaviour
{
    public List<Branch> Branches;

    void OnEnable()
    {
        // Tags is cleared when you go to the first Scene in the Build Scenne Index
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            GameObject.Find("Player").GetComponent<PlayerTags>().Tags.Clear();
        }
    }

    // Check whether the needed ingredients for a recipe are available
    bool containsAll(List<string> _neededTags, List<string> availableTags)
    {
        int len = _neededTags.Count;
        if (availableTags.Count != _neededTags.Count)
        {
            return false;
        }

        availableTags.Sort();
        _neededTags.Sort();

        for (int i = 0; i < len; i++)
        {
            if (availableTags[i] != _neededTags[i])
            {
                return false;
            }
        }
        return true;
    }

    // Check if any of the recipe in the array of recipes can be made
    public Branch haveBranch(List<string> _availableTags)
    {
        foreach (Branch branch in Branches)
        {
            if (containsAll(branch.Tags, _availableTags))
            {
                return branch;
            }
        }
        return new Branch();
    }

    public string GetNextLevel()
    {
        List<string> tags = GameObject.Find("Player").GetComponent<PlayerTags>().Tags;

        return(haveBranch(tags).SceneName);
    }
}
