using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{

    //Skor hesaplamaları

    [SerializeField]Text bestScoreTxt,lastScoreTxt,scoreBest,scoreLast;
    float last,best;
    void Start()
    {
        Time.timeScale = 1;
        last = TheAnt.points;
        lastScoreTxt.text = "Last: "+TheAnt.pointTxt.text;
        scoreLast.text = lastScoreTxt.text;
        best = float.Parse(PlayerPrefs.GetFloat("best").ToString());
        CalculateBest();

    }
    // Skor
    void CalculateBest()
    {
        if (best == null || best == 0|| best < last)
        {
            best = last;
            PlayerPrefs.SetFloat("best", last);
            PlayerPrefs.Save();
        }

        best = float.Parse(PlayerPrefs.GetFloat("best").ToString());
        bestScoreTxt.text = "Best: "+string.Format("{0:0.0}", best) + " m";
        scoreBest.text = bestScoreTxt.text;
        }
}
