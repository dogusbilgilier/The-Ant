using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class TheAnt : MonoBehaviour
{
    public static bool dead = false;
    int health;
    float points = 0;
    Rigidbody body;
    [SerializeField] GameObject[] healthObj = new GameObject[5];
    [SerializeField] Material[] maxHealth= new Material[5];
    [SerializeField] Material unhealth;

    [SerializeField] GameObject joystickLeft,joystickRight,pause,theEnd;
    GameObject joystick;

    SkinnedMeshRenderer[] healthBar = new SkinnedMeshRenderer[5];

    void Start()
    {
        body = GetComponent<Rigidbody>();

        if (MusicPlayer.source != null)
        {
            if (!MusicPlayer.source.isPlaying)
                MusicPlayer.source.Play();
        }
      

        //Joystick ayarları
        if (PlayerPrefs.GetInt("Joystick")==0)
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


    void HealthDown()
    {
        if (health > 0)
        {
            GetComponent<CapsuleCollider>().enabled = false;
            body.isKinematic = true;

            health--;
            EventManager.OnHealthDown.Invoke();
            

            for (int i = 4; health - 1 < i; i--)
                healthBar[i].material = unhealth;

            if (health == 0)
                Dead();
            StartCoroutine(HealthDownEffect());
            StartCoroutine(WaitForColliderON());
        }
    }

    IEnumerator WaitForColliderON()
    {
        yield return new WaitForSeconds(1.4f);
        GetComponent<CapsuleCollider>().enabled = true;
        body.isKinematic = false;
    }

    IEnumerator HealthDownEffect()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.15f);
            healthBar[health].material = maxHealth[health];
            yield return new WaitForSeconds(0.15f);
            healthBar[health].material = unhealth;
           
        }
    }

    public void HealUp()
    {
      EventManager.OnHealUp.Invoke();
        if (health < 5)
        {
            health++;
            for (int i = 0; i < health; i++)
                healthBar[i].material = maxHealth[i];
        }
    }

    void Dead()
    {
        Debug.Log("Death");
        EventManager.OnDeath.Invoke();
       
        joystick.SetActive(false);
        pause.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
            HealthDown();
       
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.relativeVelocity.magnitude > 6 && collision.gameObject.tag.Equals("drop"))
            HealthDown();
    }
       
}