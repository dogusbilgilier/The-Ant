using UnityEngine;

public class DestroyPlane : MonoBehaviour
{
    //Karıncanın geçtiği alanı yok eder
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("Ant"))
            Destroy(gameObject.transform.parent.gameObject);    
    }
}
