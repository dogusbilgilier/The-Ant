using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TheAnt : MonoBehaviour
{
    public static bool dead = false;
    int health;
    public static float points=0;
    public static Text pointTxt;
    Rigidbody body;
    [SerializeField] GameObject[] healthObj = new GameObject[5];
    [SerializeField] Material[] maxHealth= new Material[5];
    [SerializeField] Material unhealth;
    [SerializeField] AudioClip deadMusic, eatSFX, crushSFX;
    [SerializeField] GameObject joystickLeft,joystickRight,pause,theEnd;
    GameObject joystick;
    FadeIn fadeIn;


    
    SkinnedMeshRenderer[] healthBar = new SkinnedMeshRenderer[5];

    void Start()
    {
        //Başlangıç normalleri
        fadeIn = FindObjectOfType<FadeIn>();
        pointTxt = GameObject.FindGameObjectWithTag("Points").GetComponent<Text>();
        pointTxt = GameObject.FindGameObjectWithTag("Points").GetComponent<Text>();
        body = GetComponent<Rigidbody>();
        

        if (!MusicPlayer.source.isPlaying)
            MusicPlayer.source.Play();

        //Joystick ayarları
        if (JoystickOption.stickOr.Equals("Left"))
        {
            joystick = joystickLeft;
            joystickRight.SetActive(false);
        }
        else
        {
            joystick = joystickRight;
            joystickLeft.SetActive(false);
        }
        
        pause.SetActive(true);
        dead = false;
        theEnd.SetActive(false);

        health = 3;
        //Karınca HealtBarı Tanımlama
        for (int i = 0; i < 5; i++)
            healthBar[i] = healthObj[i].GetComponent<SkinnedMeshRenderer>();
        //3 can ile başladı 
        for (int i = 4; health - 1 < i; i--)
            healthBar[i].material = unhealth;
    }

    private void Update()
    {
        Score();
    }

    void Score()
    {
        // Metre Hesabı
        points = (transform.position.z + 26) / 10f;
        pointTxt.text = string.Format("{0:0.0}", points) + " m";
    }
    void HealthDown()
    {
        if (health > 0)
        {
            health--;
            AudioSource.PlayClipAtPoint(crushSFX, Camera.main.transform.position);

            for (int i = 4; health - 1 < i; i--)
                healthBar[i].material = unhealth;

            if (health == 0)
                Dead();
        }
    }

    public void HealUp()
    {
        AudioSource.PlayClipAtPoint(eatSFX, Camera.main.transform.position);
        if (health < 5)
        {
            health++;
            for (int i = 0; i < health; i++)
                healthBar[i].material = maxHealth[i];
        }
    }

    void Dead()
    {
        fadeIn.Fade();
        MusicPlayer.source.Stop();
        AudioSource.PlayClipAtPoint(deadMusic, Camera.main.transform.position);
        joystick.SetActive(false);
        pause.SetActive(false);
        dead = true;
        
        StartCoroutine(WaitForEndScene());
        StartCoroutine(WaitForTxt());
    }

    IEnumerator WaitForTxt()
    {
        yield return new WaitForSeconds(0.6f);
        theEnd.SetActive(true);
    }

    IEnumerator WaitForEndScene()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("EndScene");
    }
    
    //Çarpışma ve tetiklenme olayları
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("colliderObj") || other.name.Contains("wheel")||other.name.Contains("Flip"))
        {
            body.constraints = RigidbodyConstraints.FreezeAll;
            HealthDown();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Equals("colliderObj") || other.name.Contains("wheel")|| other.gameObject.name.Contains("Flip"))
        {
            body.constraints = RigidbodyConstraints.FreezePositionY;
            body.freezeRotation = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // kola ile çarpışma şiddetine göre can düşümü
        if (collision.gameObject.name.Contains("cola"))
        {
            Debug.Log(collision.relativeVelocity.magnitude);
            if (collision.relativeVelocity.magnitude > 6)
            {
                HealthDown();
            }
        }
       
    }



   
}
