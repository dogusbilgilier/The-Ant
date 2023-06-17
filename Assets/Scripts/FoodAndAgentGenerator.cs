
using UnityEngine;

public class FoodAndAgentGenerator : MonoBehaviour
{
    [SerializeField] GameObject  shoeContainer, shoe,flip;
    GameObject ant;
    [SerializeField] GameObject[] foodObjs = new GameObject[4];
    GameObject plane;
    float randomX, randomZ, planeZPos;
    Vector3 foodPos,shoePos;
    float shoeInstTime,timer;
    int targetShoeCount=20;
    int shoeCount=0;
    GameObject foodContainer;
    GameObject[] foods = new GameObject[5];
    RaycastHit hit;
    int foodCount;

    void Start()
    {
        ant = GameObject.FindGameObjectWithTag("Player");
        foodContainer = this.gameObject.transform.parent.gameObject;
        shoeInstTime = 0.05f;
        plane = foodContainer.transform.parent.gameObject;
        planeZPos = plane.GetComponent<Transform>().localPosition.z;
        InstantiateFoods();
    }
    void Update()
    {
        // ayakkabılar, aynı anda hareket etmemeleri
        // için farklı zamanlarda oluşturuluyor

        if (timer >= shoeInstTime && shoeCount <= targetShoeCount)
        {
            InstantiateShoes();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void InstantiateFoods()
    {
        if (plane.name.Contains("Home"))
            foodCount = 2;
        else
            foodCount = 4;

        for (int i = 0; i < foodCount;)
        {
            if(plane.name.Contains("Home"))
                randomZ = Random.Range(planeZPos - 15, planeZPos + 15);
            else
                randomZ = Random.Range(planeZPos - 20, planeZPos + 30);

            randomX = Random.Range(10, -10);
            foodPos = new Vector3(randomX, 0.1f, randomZ);

            //yemek herhangi bir ojenin olmadığı ve karıncanın ulaşabileceği bir yerde olmalı
            // ışınlarla yemeğin herhangi bir objenin içinde olmadığına emin ol
            if (Vector3.Distance(foodPos, ant.transform.position) > 5 &&
               !Physics.Raycast(foodPos, transform.TransformDirection(Vector3.forward), out hit, 2f)&&
               !Physics.Raycast(foodPos, transform.TransformDirection(Vector3.up), out hit, 2f)&&
               !Physics.Raycast(foodPos, transform.TransformDirection(Vector3.back), out hit, 2f)&&
               !Physics.Raycast(foodPos, transform.TransformDirection(Vector3.left), out hit, 2f)&&
               !Physics.Raycast(foodPos, transform.TransformDirection(Vector3.right), out hit, 2f))
            {
                foods[i] = Instantiate(foodObjs[i], foodPos, foodObjs[i].transform.rotation, transform.parent);
                i++;
            }
        }
    }
    public void InstantiateShoes()
    {
        if (plane.name.Contains("Pavement"))
        {
            targetShoeCount = 30;

            randomX = Random.Range(-18, 18);
            randomZ = Random.Range(planeZPos - 25, planeZPos + 25);
            shoePos = new Vector3(randomX, 0, randomZ);

            if (Vector3.Distance(shoePos, ant.transform.position) > 7)
            {
                Instantiate(shoe, shoePos, Quaternion.identity, shoeContainer.transform);
                shoeCount++;
            }
            else
                InstantiateShoes();
        }

        if (plane.name.Contains("Home"))
        {

            targetShoeCount = 5;

            randomX = Random.Range(-11, 11);
            randomZ = Random.Range(planeZPos - 25, planeZPos + 25);
            shoePos = new Vector3(randomX, 0, randomZ);

            if (Vector3.Distance(shoePos, ant.transform.position) > 5)
            {
                GameObject flipFlop = Instantiate(flip, shoePos, Quaternion.identity, shoeContainer.transform);
                flipFlop.transform.localPosition = new Vector3(flipFlop.transform.localPosition.x, 0, flipFlop.transform.localPosition.z);
                shoeCount++;
            }
            else
                InstantiateShoes();
        }
    }
}
