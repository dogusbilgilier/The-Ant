using UnityEngine;

public class AntMovement : MonoBehaviour
{
    Joystick joystick;
    [SerializeField] Joystick JLeft, JRight;
    Vector3 moveDirection;
    Animator animator;
    [SerializeField] private float speed=3f;
    Camera mainCam;
    void Start()
    {
        RoadCam.camAnim = false;
        mainCam = Camera.main;
        animator = GetComponentInChildren<Animator>();

        if (JoystickOption.stickOr.Equals("Left"))
        {
            joystick = JLeft.GetComponent<FixedJoystick>();
            JRight.gameObject.SetActive(false);
        }
        else
        {
            joystick = JRight.GetComponent<FixedJoystick>();
            JLeft.gameObject.SetActive(false);
        }

    }
    void FixedUpdate()
    {
        if (!TheAnt.dead)
            Move();
        else
            RoadCam.camAnim = false;
    }

    void Move()
    {
        //Kameranın takibi ve yüksekliği

        if (RoadCam.camAnim) 
            RoadCam.CamUp();
        else
            RoadCam.CamDown();
        

        mainCam.transform.position = new Vector3(transform.position.x,
                                                mainCam.transform.position.y,
                                                transform.position.z - 1.5f);
        //Karınca hareketi
        moveDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        transform.Translate(moveDirection * Time.deltaTime * speed, Space.World);

        if (moveDirection != new Vector3(0, 0, 0))
        {
            animator.speed = 1.5f;

            // Karıncanın gidilen yöne bakma hızı
            transform.rotation = Quaternion.Lerp(transform.rotation,
                                 Quaternion.LookRotation(moveDirection),
                                 Time.deltaTime * 20);
        }
        else
            animator.speed = 0f;
    }
}
