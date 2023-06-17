using UnityEngine;

public class AntMovement : MonoBehaviour
{
    Joystick joystick;
    [SerializeField] Joystick JLeft, JRight;
    Vector3 moveDirection;
    Animator animator;
    [SerializeField] private float speed = 3f;
    Camera mainCam;
    bool isDeath;
    void OnEnable()
    {
        EventManager.OnDeath += OnDeath;
    }
    void OnDisable()
    {
        EventManager.OnDeath -= OnDeath;
    }
    void OnDeath()
    {
        isDeath = true;
    }
    void Start()
    {

        mainCam = Camera.main;
        animator = GetComponentInChildren<Animator>();

        if (PlayerPrefs.GetInt("Joystick",0) == 0)
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
    }
    void LateUpdate()
    {
        mainCam.transform.position = new Vector3(transform.position.x,
                                                mainCam.transform.position.y,
                                                transform.position.z - 1.5f);
    }

    void Move()
    {
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
