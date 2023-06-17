using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManger : MonoBehaviour
{
    [SerializeField] Text[] theEndTexts;
    [SerializeField] Image theEndBackground;
    [SerializeField] Text pointText;
    GameObject ant;
    float  points;
    void Start()
    {
        PlayerPrefs.SetFloat("LastPoint", 0f);
        ant = GameObject.FindGameObjectWithTag("Player");
    }
    void OnEnable()
    {
        EventManager.OnDeath += OnDeath;
    }
    void OnDisable()
    {
        EventManager.OnDeath -= OnDeath;
    }


    void Update()
    {
        points = (ant.transform.position.z + 26) / 10f;
        pointText.text = string.Format("{0:0.0}", points) + " m";
    }

    private void OnDeath()
    {
        for (int i = 0; i < theEndTexts.Length; i++)
        {
            theEndTexts[i].gameObject.SetActive(true);
            theEndTexts[i].DOFade(1, 1);
        }
        theEndBackground.DOFade(1, 1);

        PlayerPrefs.SetFloat("LastPoint", points);
    }
}
