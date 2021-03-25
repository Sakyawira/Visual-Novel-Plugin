using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TwitterShare : MonoBehaviour
{
    public void openTwitter()
    {
        string twitterAddress = "http://twitter.com/intent/tweet"; 
        string message = "GET THIS AWERSOME GAME ";//text string 
        string descriptionParameter = "Dream Catcher "; 
        string appStoreLink = "https://play.google.com/store/apps/details?id=com.sakyawira.dreamcatcher"; 
        Application.OpenURL(twitterAddress + "?text=" + UnityWebRequest.EscapeURL(message + " " + descriptionParameter + " " + appStoreLink));
    }
}