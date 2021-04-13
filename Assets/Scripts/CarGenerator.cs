using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    float instTime,time;
    GameObject instCar,plane;
    [SerializeField] GameObject car;
    Vector3 leftSide, leftSide2, rightSide,rightSide2;

    void Start()
    {
        time = 0;
    }
    void Update()
    {
        time += Time.deltaTime;

        if (time >= instTime)
        {

            leftSide = new Vector3(-50f, 2.19f, Random.Range(-21, -26));
            leftSide2 = new Vector3(-50f, 2.19f, Random.Range(14, 8));
            rightSide = new Vector3(50, 2.19f, Random.Range(26, 20));
            rightSide2 = new Vector3(50, 2.19f, Random.Range(-9, -13));

            instCar = Instantiate(car, leftSide, car.transform.rotation, gameObject.transform);
            instCar.transform.localPosition = leftSide;

            instCar = Instantiate(car, leftSide, car.transform.rotation, gameObject.transform);
            instCar.transform.localPosition = leftSide2; 

            instCar = Instantiate(car, rightSide, car.transform.rotation, gameObject.transform);
            instCar.transform.localPosition = rightSide;
            instCar.transform.rotation = Quaternion.Euler(0,270,0);
            
            instCar = Instantiate(car, rightSide2, car.transform.rotation, gameObject.transform);
            instCar.transform.localPosition = rightSide2;
            instCar.transform.rotation = Quaternion.Euler(0, 270, 0);

            time = 0;
            instTime = Random.Range(1.5f, 4);
        }
    }
}
