using DG.Tweening;
using UnityEngine;

public class RoadCam : MonoBehaviour
{
    Camera mainCamera;

    void OnEnable()
    {
        EventManager.OnEnterRoad += CamUp;
        EventManager.OnLeaveRoad += CamDown;
    }
    void OnDisable()
    {
        EventManager.OnEnterRoad -= CamUp;
        EventManager.OnLeaveRoad -= CamDown;
    }
    void Start()
    {
       mainCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            EventManager.OnEnterRoad.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            EventManager.OnLeaveRoad.Invoke();
    }
    void CamUp()
    {
        mainCamera.transform.DOMoveY(8.5f, 1);
    }
    void CamDown()
    {
        mainCamera.transform.DOMoveY(6.5f, 1);
    }

}
