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
}
