using UnityEngine;
using GoogleMobileAds.Api;

public class AdLoader : MonoBehaviour
{
    private InterstitialAd ad;
    string adID = "ca-app-pub-3493106156219225/5115514511";
    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        LoadAds();
    }
 
    public void LoadAds()
    {
        ad = new InterstitialAd(adID);
        AdRequest request = new AdRequest.Builder().Build();
        ad.LoadAd(request);
    }
   public void ShowAds()
    {
        if (ad.IsLoaded())
            ad.Show();

       // Destroy(gameObject);
    }

}
