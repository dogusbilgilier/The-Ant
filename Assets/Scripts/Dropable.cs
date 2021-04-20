using UnityEngine;

public class Dropable : MonoBehaviour
{
    //Karıncanın üzerine düşecek objeleri oluşturur

    [SerializeField] GameObject colaCan;
    GameObject theAnt;
    float dropTime,timer;

    void Start()
    {
        theAnt = GameObject.FindGameObjectWithTag("Player");
        dropTime = Random.Range(10, 20);
    }
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= dropTime)
        {
            Instantiate(colaCan,new Vector3(theAnt.transform.position.x,
                theAnt.transform.position.y+4,
                theAnt.transform.position.z),
                colaCan.transform.rotation,gameObject.transform);

            timer = 0;
            dropTime = Random.Range(10, 30);
        }
    }
}
