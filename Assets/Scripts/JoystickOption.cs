using UnityEngine;
using UnityEngine.UI;

public class JoystickOption : MonoBehaviour
{
    [SerializeField] public Image leftImg1, leftImg2, rightImg1, rightImg2;
    private void Start()
    {
        leftImg1.color = Color.green;
        leftImg2.color = Color.green;
        PlayerPrefs.SetInt("Joystick", 0);
    }
    public  void OptionLeft()
    {
        if (rightImg1.color== Color.green)
        {
            rightImg2.color = Color.white;
            rightImg1.color = Color.white;
        }
        leftImg1.color = Color.green;
        leftImg2.color = Color.green;
        PlayerPrefs.SetInt("Joystick", 0);
    }
    public  void OptionRight()
    {
        if (leftImg1.color == Color.green)
        {
            leftImg1.color = Color.white;
            leftImg2.color = Color.white;
        }
        rightImg1.color = Color.green;
        rightImg2.color = Color.green;
        PlayerPrefs.SetInt("Joystick", 1);
    }
}
