using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    bool isUserAuthenticated = false;
    // Use this for initialization
    void Start()
    {
        PlayGamesPlatform.Activate(); // activate playgame platform
        PlayGamesPlatform.DebugLogEnabled = true; //enable debug log
    }

    // Update is called once per frame
    void Update()
    {
        if (!isUserAuthenticated)
        {
            Social.localUser.Authenticate((bool success) => {
                if (success)
                {
                    Debug.Log("You've successfully logged in");
                    isUserAuthenticated = true; // set value to true
                }
                else
                {
                    Debug.Log("Login failed for some reason");
                }
            });
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Continue()
    {

    }

    public void OpenAchievement()
    {
        Social.localUser.Authenticate((bool success) => {
            if (success)
            {
                Debug.Log("You've successfully logged in");
                Social.ShowAchievementsUI();
            }
            else
            {
                Debug.Log("Login failed for some reason");
            }
        });
    }

    public void AddAchievement()
    {
        Social.ReportProgress(Achievement.achievement_eat_breakfast, 100, (bool sucsess) => { });
    }
}