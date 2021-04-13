using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static AudioSource source;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length>1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
        source = gameObject.GetComponent<AudioSource>();
        if (!source.isPlaying)
        {
            source.Play();
            source.volume = 1f;
        }
        
    }

  
}
