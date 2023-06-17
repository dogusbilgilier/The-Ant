using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    [SerializeField] Text bestScoreTxt, lastScoreTxt;
    float last,best;
    void Start()
    {
        Time.timeScale = 1;
        last = float.Parse(PlayerPrefs.GetFloat("LastPoint").ToString());
        lastScoreTxt.text = "Last: "+string.Format("{0:0.0}", last) + " m";

        best = float.Parse(PlayerPrefs.GetFloat("best").ToString());
        CalculateBest();

    }
    // Skor
    void CalculateBest()
    {
        if (best == 0|| best < last)
        {
            best = last;
            PlayerPrefs.SetFloat("best", last);
            PlayerPrefs.Save();
        }

        best = float.Parse(PlayerPrefs.GetFloat("best").ToString());
        bestScoreTxt.text = "Best: " + string.Format("{0:0.0}", best) + " m";
        }
}
