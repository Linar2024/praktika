using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class knife : MonoBehaviour
{
    public Animator animator;
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
        if(animator.GetBool("showbullets") == false)
        {
            animator.SetBool("useknife", true);
            StartCoroutine(ShootOFf());
        }
    }
    IEnumerator ShootOFf()
    {

        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }
}
