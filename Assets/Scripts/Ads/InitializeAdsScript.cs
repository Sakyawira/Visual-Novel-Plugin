using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAdsScript : MonoBehaviour
{
    string gameId = "4058630";
    bool testMode = false;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }
}