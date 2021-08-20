using UnityEngine;

public class ShowAds : MonoBehaviour
{
    AdLoader ads;
    void Start()
    {
        ads = FindObjectOfType<AdLoader>();
        ads.ShowAds();
        ads.LoadAds();
    }

}
