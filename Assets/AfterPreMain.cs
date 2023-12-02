using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class AfterPreMain : MonoBehaviour
{
    //public AnimatorController animationController;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(switchAnimator());
    }

    private IEnumerator switchAnimator()
    {
        yield return new WaitForSeconds(1.15f);
        //gameObject.GetComponent<Animator>().runtimeAnimatorController = animationController;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        StartCoroutine(setupAnimator());
    }
    private IEnumerator setupAnimator()
    {
        yield return new WaitForSeconds(1f);
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }
}
