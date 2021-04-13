using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAds : MonoBehaviour
{
    AdLoader ads;
    void Start()
    {
        ads = FindObjectOfType<AdLoader>();
        ads.ShowAds();
    }

}
