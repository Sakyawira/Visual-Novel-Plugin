using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //bool isUserAuthenticated = false;
    // Use this for initialization
    void Start()
    {
        try
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();
            Social.localUser.Authenticate((bool success) => {
                if (success)
                {
                    Debug.Log("You've successfully logged in");
                    //isUserAuthenticated = true; // set value to true
                }
                else
                {
                    Debug.Log("Login failed for some reason");
                }
            });
        }
        catch (Exception exception)
        {
            Debug.Log(exception);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isUserAuthenticated)
        //{
        //    Social.localUser.Authenticate((bool success) => {
           
        //    });
        //}
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
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
        //Social.localUser.Authenticate((bool success) => {
        //    if (success)
        //    {
        //        Debug.Log("You've successfully logged in");
        //        Social.ShowAchievementsUI();
        //    }
        //    else
        //    {
        //        Debug.Log("Login failed for some reason");
        //    }
        //});
    }

    public void AddAchievement()
    {
        Social.ReportProgress(Achievement.achievement_eat_breakfast, 100, (bool sucsess) => { });
    }
}