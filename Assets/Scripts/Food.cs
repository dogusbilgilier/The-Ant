using UnityEngine;

public class Food : MonoBehaviour
{
    new LineRenderer renderers;
    Vector3[] positions;
    float offset = 1;
    GameObject antNose;
    TheAnt ant;
    float distance;

    void Start()
    {  
        antNose = GameObject.FindGameObjectWithTag("Nose");
        ant = antNose.transform.parent.gameObject.GetComponent<TheAnt>();
        positions = new Vector3[2];
        renderers = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {

        //LineRenderer ayarları
        distance = Vector3.Distance(gameObject.transform.position, antNose.transform.position);
        
        if (distance <= 20f)
        {
            positions[0] = new Vector3(gameObject.transform.position.x, 0.3f, gameObject.transform.position.z);
            positions[1] = new Vector3 (antNose.transform.position.x,0.3f,antNose.transform.position.z);

            offset = Time.time * 0.6f;

            renderers.material.mainTextureOffset = new Vector2(offset, 1); // koku efekti için texture animasyonu
            renderers.SetPositions(positions);
            renderers.enabled = true;
        }
        else
            renderers.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Ant"))
        {
            Destroy(this.gameObject);
            ant.HealUp();
        }
    }

 
}
