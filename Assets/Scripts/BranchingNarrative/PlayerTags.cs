/***********************
  File Name   :   PlayerTags.cs
  Description :   define a singleton tags container, which allows the game to check the choices the player has made
  Author/s    :   Sakyawira Nanda Ruslim
  Mail        :   Sakyawira@gmail.com
********************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void AddTag(string newTag)
    {
        if (Tags.Contains(newTag) == false && newTag != "")
        {
            Tags.Add(newTag);
        }
    }
}