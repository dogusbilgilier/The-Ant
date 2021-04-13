using UnityEngine;

public class ColaCan : MonoBehaviour
{
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 60 || gameObject.transform.position.y <= -1)
        {
            Destroy(this.gameObject);
        }
       
    }
}
