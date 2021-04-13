using UnityEngine;

public class RotateButton : MonoBehaviour
{
    // Play butonunu döndürür
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -1) * 20 * Time.deltaTime, Space.Self);
    }
}
