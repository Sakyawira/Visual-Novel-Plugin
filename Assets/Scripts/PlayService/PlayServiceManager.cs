using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayServiceManager : MonoBehaviour
{
    bool isUserAuthenticated = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isUserAuthenticated)
        { 
            Social.localUser.Authenticate((bool success) => {
                if (success)
                {
                    Debug.Log("You have succeflly login!");
                    isUserAuthenticated = true;
                }
                else
                {
                    Debug.Log("Login failed for some reason");
                }
            });
        } 
    }

    public void GetAchieve()
    {
        Social.ReportProgress(Achievement.achievement_eat_breakfast, 100, (bool success) => { });
        OpenAchievements();
        Debug.Log("Achieve Pressed");
    }

    public void OpenAchievements()
    {
        Social.localUser.Authenticate((bool success) =>{
            if (success)
            {
                Debug.Log("You've succesfully logged in.");
                Social.ShowAchievementsUI();
            }
            else
            {
                Debug.Log("Login failed for some reason");
            }
        });
    }
}
