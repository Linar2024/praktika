using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator animator;
    public GameObject hide;
    public GameObject unhide;
    public GameObject canvas;
    public ParticleSystem particle;
    public GameObject light;
    // Start is called before the first frame update
    void Start()
    {

        unhide.SetActive(false);
        light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    public void TakeGun()
    {
        if (animator.GetBool("gun") == false)
        {
            animator.SetBool("takegun", true);
            canvas.SetActive(false);
        }
            
    }
    IEnumerator Particle()
    {
        light.SetActive(true);
        particle.Play();
        yield return new WaitForSeconds(0.1f);
        light.SetActive(false);
    }
    public void Shoot()
    {
        if (animator.GetBool("gun"))
        {
            animator.SetBool("gun", false);
            animator.SetBool("shoot", true);
        }
            
    }
    IEnumerator ShootOFf()
    {
        animator.SetBool("shoot", false);
        yield return new WaitForSeconds(0.01f);
        canvas.SetActive(true);
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
}
