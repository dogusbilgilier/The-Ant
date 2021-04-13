using UnityEngine;

public class DayCycle : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime, Space.Self);
    }
}
