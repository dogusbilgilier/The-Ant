using UnityEngine;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject wheel1, wheel2;
    MeshRenderer car,wh1,wh2,eg;
    
    public Material[] colors = new Material[6];

    void Start()
    {
       
        wheel1 = transform.GetChild(1).gameObject;
        wheel2 = transform.GetChild(2).gameObject;

        eg = transform.GetChild(3).gameObject.GetComponent<MeshRenderer>();
        car = transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        wh1 = wheel1.GetComponent<MeshRenderer>();
        wh2 = wheel2.GetComponent<MeshRenderer>();

        GetColoredCar(wh1);
        GetColoredCar(wh2);
        GetColoredCar(car);
        GetColoredCar(eg);
       
    }

    void GetColoredCar(MeshRenderer renderer)
    {
        renderer.material = colors[Random.Range(0, 5)];
    }

    void Update()
    {
        wheel1.transform.Rotate(new Vector3(1, 0, 0) * 300 * Time.deltaTime, Space.Self);
        wheel2.transform.Rotate(new Vector3(1, 0, 0) * 300 * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.forward * Time.deltaTime * 15);

        if (transform.position.x >= 55 || transform.position.x <= -55)
            Destroy(this.gameObject);

    }

   
}
