using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class beer : MonoBehaviour
{
    public Animator animator;
    public Animator animator2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        if (animator.GetBool("showbullets") == false && animator2.GetBool("playerturn") && animator2.GetBool("getitems") == false && animator.GetBool("useknife") == false)
        {
            animator.SetBool("usebear", true);
            StartCoroutine(ShootOFf());
        }
    }
    IEnumerator ShootOFf()
    {

        yield return new WaitForSeconds(0.55f);
        gameObject.SetActive(false);
    }
}
