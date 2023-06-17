using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip deadMusic, eatSFX, crushSFX;
    [SerializeField] Transform camTransform;
    
    void Start()
    {
        camTransform= Camera.main.transform;
    }
    void OnEnable()
    {
        EventManager.OnDeath += OnDeath;
        EventManager.OnHealthDown += OnHealthDown;
        EventManager.OnHealUp += OnHealUp;
    }
    void OnDisable()
    {
        EventManager.OnDeath -= OnDeath;
        EventManager.OnHealthDown -= OnHealthDown;
        EventManager.OnHealUp -= OnHealUp;
    }
    void OnDeath()
    {
        if (MusicPlayer.source)
            MusicPlayer.source.Stop();
        AudioSource.PlayClipAtPoint(deadMusic, camTransform.position);
    }
    void OnHealthDown()
    {
        AudioSource.PlayClipAtPoint(crushSFX, camTransform.position);
    }
    void OnHealUp()
    {
        AudioSource.PlayClipAtPoint(eatSFX, camTransform.position);
    }

}
