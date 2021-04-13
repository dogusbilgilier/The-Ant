using UnityEngine;

public class RoadCam : MonoBehaviour
{
    public static bool camAnim ;

    private void Start()
    {
        camAnim = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        camAnim = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
            camAnim = false;
    }
   public static void CamUp()
    {
        Vector3 camUpPos = new Vector3(Camera.main.transform.position.x,
                                         8.5f, Camera.main.transform.position.z);
        if (Camera.main.transform.position.y != 8.5)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position,
                                        camUpPos, Time.deltaTime);
        }

    }
    public static void CamDown()
    {
        Vector3 camDownPos = new Vector3(Camera.main.transform.position.x,
                                         6.5f, Camera.main.transform.position.z);

        if (Camera.main.transform.position.y != 6.5)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position,
                                        camDownPos, Time.deltaTime);
        }
        else
            camAnim = false;
        
        
    }

}
