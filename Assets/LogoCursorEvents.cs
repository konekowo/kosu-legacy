using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LogoCursorEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool UserClicked;
    public Animator animator;
    public Animator backgroundAnimator;
    public Animator buttonAnimator;

    private void Start()
    {
        animator = gameObject.transform.parent.GetComponent<Animator>();
    }

    public void LogoClick() // 3
    {
        if (UserClicked == false)
        {
            animator.SetBool("UserClicked", true);
            backgroundAnimator.SetBool("BackgroundFade", true);
            buttonAnimator.SetBool("UserClicked", true);
            UserClicked = true;
        }
        else
        {
            animator.SetBool("UserClicked", false);
            backgroundAnimator.SetBool("BackgroundFade", false);
            buttonAnimator.SetBool("UserClicked", false);
            UserClicked = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("Hover", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("Hover", false);
    }

    private void closeAfterClick()
    {
    }
}