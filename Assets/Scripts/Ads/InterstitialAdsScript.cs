using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAdsScript : MonoBehaviour
{
    string gameId = "4058630";
    bool testMode = true;

    // Initialize the Ads service:
    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }

    public void ShowAds()
    {
        // Show an ad:
        Advertisement.Show();
    }
}