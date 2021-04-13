using UnityEngine;

public class NewPlaneFront : MonoBehaviour
{
    //Karınca bulunduğu bölgeyi geçerken önünde yeni oluşacak bölgeyi oluşturur

    [SerializeField] GameObject[] planes = new GameObject[2];
    GameObject instPlane;
    int planecount=0;

    private void Start()
    {
        transform.localPosition = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Ant"))
        {
            int planeInt = Random.Range(0, 2);
            Debug.Log("Create "+planeInt);

            instPlane=Instantiate(planes[planeInt], new Vector3(gameObject.transform.position.x,
                gameObject.transform.position.y, gameObject.transform.position.z + 60),
                Quaternion.identity, transform.parent.transform.parent);

            instPlane.name = planes[planeInt].name + planecount.ToString();
            planecount++;

            Destroy(this.gameObject);
        }

    }
}
