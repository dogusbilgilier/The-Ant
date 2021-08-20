﻿using System.Collections;
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

        if (MusicPlayer.source != null)
        {
            if (!MusicPlayer.source.isPlaying)
                MusicPlayer.source.Play();
        }
      

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
            GetComponent<CapsuleCollider>().enabled = false;
            body.isKinematic = true;

            health--;
            AudioSource.PlayClipAtPoint(crushSFX, Camera.main.transform.position);

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
        yield return new WaitForSeconds(0.15f);
        healthBar[health].material = unhealth;
        yield return new WaitForSeconds(0.15f);
        healthBar[health].material = maxHealth[health];
        yield return new WaitForSeconds(0.15f);
        healthBar[health].material = unhealth;
        yield return new WaitForSeconds(0.15f);
        healthBar[health].material = maxHealth[health];
        yield return new WaitForSeconds(0.15f);
        healthBar[health].material = unhealth;
        yield return new WaitForSeconds(0.15f);
        healthBar[health].material = maxHealth[health];
        yield return new WaitForSeconds(0.15f);
        healthBar[health].material = unhealth;
        yield return new WaitForSeconds(0.15f);
        healthBar[health].material = maxHealth[health];
        yield return new WaitForSeconds(0.15f);
        healthBar[health].material = unhealth;
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
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("enemy"))
        {
            HealthDown();
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.relativeVelocity.magnitude > 6 && collision.gameObject.tag.Equals("drop"))
            HealthDown();
    }
       
}