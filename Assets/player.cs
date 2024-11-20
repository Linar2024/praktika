using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Animator animator;
    public GameObject hide;
    public GameObject unhide;
    public GameObject canvas;
    public ParticleSystem particle;
    public GameObject rotateobject;
    int enemyhealth = 5;
    public Button shootenemy;
    
    //public Button shootenemy;
    // Speed of rotation
    // Start is called before the first frame update
    void Start()
    {
        //shootenemy.interactable = false;
        //shootenemy.gameObject.SetActive(false);
        unhide.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
       

    }
    public void TakeGun()
    {
        if (animator.GetBool("gun") == false)
        {
            Debug.Log("takegun");
            animator.SetBool("takegun", true);
            //canvas.SetActive(false);
            //shootenemy.interactable = true;
            shootenemy.gameObject.SetActive(true);
        }
            
    }
    IEnumerator Particle()
    {
        particle.Play();
        yield return new WaitForSeconds(0.1f);
    }
    public void Shoot()
    {
        if (animator.GetBool("gun"))
        {
            Debug.Log("shoot");
            enemyhealth = enemyhealth - 1;
            animator.SetBool("gun", false);
            animator.SetBool("shoot", true);
            animator.SetInteger("enemyhealth", enemyhealth);
            //shootenemy.interactable = false;
            shootenemy.gameObject.SetActive(false);
        }
            
    }
    public void ShootSelf()
    {
        if (animator.GetBool("gun"))
        {
           
            animator.SetBool("gun", false);
            animator.SetBool("shootself", true);
            //shootenemy.interactable = false;
            shootenemy.gameObject.SetActive(false);
        }

    }
    IEnumerator ShootOFf()
    {
        animator.SetBool("shoot", false);
        animator.SetBool("shootself", false);
        yield return new WaitForSeconds(0.01f);
 
    }
    IEnumerator Takeoff()
    {
        animator.SetBool("gun", true);
        yield return new WaitForSeconds(0.01f);
        animator.SetBool("takegun", false);
    }
    IEnumerator Hide()
    {
        hide.SetActive(false);
        unhide.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        
    }
    IEnumerator UnHide()
    {
        hide.SetActive(true);
        unhide.SetActive(false);
        yield return new WaitForSeconds(0.01f);

    }
    IEnumerator Rotate()
    {
        animator.SetBool("rotate", true);
        yield return new WaitForSeconds(0.01f);
    }

}
