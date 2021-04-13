using UnityEngine;

public class BlockAnt : MonoBehaviour
{
 //Karıncanın bulunduğu alandan geri gitmesini engeller
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("Ant"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            GetComponent<BoxCollider>().isTrigger = false;
        }
            
    }
}
