using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Branch
{
    public List<string> Tags;
    public string SceneName;
}

public class StoryTags : MonoBehaviour
{
    public List<Branch> Branches;

    // Check whether the needed ingredients for a recipe are available
    bool containsAll(List<string> _neededTags, List<string> availableTags)
    {
        int len = _neededTags.Count;
        if (availableTags.Count != _neededTags.Count)
        {
            return false;
        }

        availableTags.Sort();//([](const Ingredient&LHS, const Ingredient&RHS) { return LHS > RHS; });
        _neededTags.Sort();//([](const Ingredient&LHS, const Ingredient&RHS) { return LHS > RHS; });

        for (int i = 0; i < len; i++)
        {
            /*if (_availableIngredients.Find(_neededIngredients[i]) == INDEX_NONE )*/
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
                //recipe.IsDiscovered = true;
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
