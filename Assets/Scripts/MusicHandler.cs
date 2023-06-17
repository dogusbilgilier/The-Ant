using System.Collections;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] AudioClip deadMusic;
    IEnumerator Start()
    {

        yield return new WaitForSeconds(2);

        if (!MusicPlayer.source.isPlaying)
        {
            MusicPlayer.source.Play();
            MusicPlayer.source.volume = 1f;
        }

    }
}
