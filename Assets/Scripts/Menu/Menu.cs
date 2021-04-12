using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //bool isUserAuthenticated = false;
    // Use this for initialization
    void Start()
    {
  
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