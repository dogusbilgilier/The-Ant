using UnityEngine;

public class FadeIn : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Fade()
    {
        animator.SetTrigger("fadeIn");
    }
}
