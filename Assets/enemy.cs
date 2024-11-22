using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public Animator animator;
    public Animator animator2;
    public Animator animator3;
    public Animator animator4;
    public GameObject hide;
    public GameObject unhide;
    public GameObject canvas;
    public ParticleSystem particle;
    public GameObject rotateobject;
    int enemyhealth = 5;
    int health = 5;
    public Button shootenemy;
    int[] bullets = new int[8];
    int bulletscount;
    int currentbullet =0;
    int live = 0;
    int shell = 0;
    int random = 0;
    bool can = true;
    //public Button shootenemy;
    // Speed of rotation
    // Start is called before the first frame update
    void Start()
    {
        //shootenemy.interactable = false;
        //shootenemy.gameObject.SetActive(false);
        unhide.SetActive(false);
        //bullets = new int[animator2.GetInteger("bullets")];
        
        currentbullet = animator2.GetInteger("currentbullet");
        live = animator2.GetInteger("currentlive");
        shell = animator2.GetInteger("currentshell");
        bulletscount = animator2.GetInteger("bullets") - currentbullet;
        health = animator4.GetInteger("health");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (animator3.GetBool("enemyturn") && animator3.GetBool("playerturn") == false)
        {
            if (can == true)
            {
                StartCoroutine(Ai());
                can = false;
            }
            
            
        }
        else
        {
            animator.SetBool("takegun", false);
        }
   

    }
    public void TakeGun()
    {
        if (animator.GetBool("gun") == false && animator3.GetBool("enemyturn") && animator3.GetBool("playerturn") == false && animator2.GetBool("showbullets") == false)
        {
            bulletscount = animator2.GetInteger("bullets") - currentbullet;
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


            if (live < animator2.GetInteger("live") && shell < animator2.GetInteger("shell"))
            {
                bullets[animator2.GetInteger("currentbullet")] = Random.Range(0, 2);
                if (bullets[animator2.GetInteger("currentbullet")] == 1)
                {
                    live++;
                    animator2.SetInteger("currentlive", animator2.GetInteger("currentlive") + 1);
                }
                else
                {
                    shell++;
                    animator2.SetInteger("currentshell", animator2.GetInteger("currentshell") + 1);
                }
            }
            else
            {
                if (shell < animator2.GetInteger("shell"))
                {
                    bullets[animator2.GetInteger("currentbullet")] = 0;
                    shell++;
                    animator2.SetInteger("currentshell", animator2.GetInteger("currentshell") + 1);
                }
                if (live < animator2.GetInteger("live"))
                {
                    bullets[animator2.GetInteger("currentbullet")] = 1;
                    live++;
                    animator2.SetInteger("currentlive", animator2.GetInteger("currentlive") + 1);

                }
            }

            if (bullets[animator2.GetInteger("currentbullet")] == 1)
            {
                Debug.Log("shoot");
                Debug.Log(bullets[animator2.GetInteger("currentbullet")]);
                currentbullet++;
                animator2.SetInteger("currentbullet", animator2.GetInteger("currentbullet") + 1);
                //bulletscount--;
                //animator2.SetInteger("bullets", bulletscount);
                health = health - 1;
                animator.SetBool("gun", false);
                animator.SetBool("shoot", true);
                animator4.SetInteger("health", health);
                StartCoroutine(PlayerTurn());
                shootenemy.gameObject.SetActive(false);

            }

            else if (bullets[animator2.GetInteger("currentbullet")] == 0)
            {
                Debug.Log("shootshell");
                Debug.Log(bullets[animator2.GetInteger("currentbullet")]);
                currentbullet++;
                animator2.SetInteger("currentbullet", animator2.GetInteger("currentbullet") + 1);
                //bulletscount--;
                //animator2.SetInteger("bullets", bulletscount);
                animator.SetBool("gun", false);
                animator.SetBool("shoot2", true);
                StartCoroutine(PlayerTurn());
                shootenemy.gameObject.SetActive(false);

            }
            //shootenemy.interactable = false;

           if (animator2.GetInteger("currentbullet") == animator2.GetInteger("bullets"))
            {
                bulletscount = 0;
                animator2.SetInteger("bullets", bulletscount);
                animator2.SetInteger("currentlive", 0);
                animator2.SetInteger("currentshell", 0);
                animator2.SetInteger("currentbullet", 0);
            }
        }
        
        

       
    }
    public void BulletsCount()
    {
        if (currentbullet == animator2.GetInteger("bullets"))
        {
            bulletscount = 0;
            animator2.SetInteger("bullets", bulletscount);
        }

    }
    public void ShootSelf()
    {


        if (animator.GetBool("gun"))
        {
            if (live < animator2.GetInteger("live") && shell < animator2.GetInteger("shell"))
            {
                bullets[currentbullet] = Random.Range(0, 2);
                if (bullets[currentbullet] == 1)
                {
                    live++;
                    animator2.SetInteger("currentlive", animator2.GetInteger("currentlive") + 1);
                }
                else
                {
                    shell++;
                    animator2.SetInteger("currentshell", animator2.GetInteger("currentshell") + 1);
                }
            }
            else
            {
                if (shell < animator2.GetInteger("shell"))
                {
                    bullets[currentbullet] = 0;
                    shell++;
                    animator2.SetInteger("currentshell", animator2.GetInteger("currentshell") + 1);
                }
                if (live < animator2.GetInteger("live"))
                {
                    bullets[currentbullet] = 1;
                    live++;
                    animator2.SetInteger("currentlive", animator2.GetInteger("currentlive") + 1);

                }
            }


            if (bullets[animator2.GetInteger("currentbullet")] == 1)
            {
                Debug.Log("shootself");
                Debug.Log(bullets[animator2.GetInteger("currentbullet")]);
                currentbullet++;
                animator2.SetInteger("currentbullet", animator2.GetInteger("currentbullet") + 1);
                enemyhealth = enemyhealth - 1;
                animator.SetBool("gun", false);
                animator.SetBool("shootself2", true);
                animator4.SetInteger("enemyhealth", enemyhealth);
                StartCoroutine(PlayerTurn());
                shootenemy.gameObject.SetActive(false);
            }

            else if (bullets[animator2.GetInteger("currentbullet")] == 0)
            {
                currentbullet++;
                animator2.SetInteger("currentbullet", animator2.GetInteger("currentbullet") + 1);
                animator.SetBool("gun", false);
                animator.SetBool("shootself", true);
                StartCoroutine(EnemyTurn());
                shootenemy.gameObject.SetActive(false);
            }

            if (animator2.GetInteger("currentbullet") == animator2.GetInteger("bullets"))
            {
                bulletscount = 0;
                animator2.SetInteger("bullets", bulletscount);
                animator2.SetInteger("currentlive", 0);
                animator2.SetInteger("currentshell", 0);
                animator2.SetInteger("currentbullet", 0);
            }
        }
        
    }
    IEnumerator ShootOFf()
    {
        animator.SetBool("shoot", false);
        animator.SetBool("shoot2", false);
        animator.SetBool("shootself", false);
        animator.SetBool("shootself2", false);
        yield return new WaitForSeconds(0.01f);

    }
    IEnumerator Ai()
    {
        int choose = Random.Range(0, 2);
        yield return new WaitForSeconds(2f);     
        TakeGun();
        yield return new WaitForSeconds(2f);
        if (choose == 0)
        {
            Shoot();
        }
        if (choose == 1)
        {
            ShootSelf();
        }
        yield return new WaitForSeconds(4f);
        can = true;
    }
    IEnumerator PlayerTurn()
    {

        yield return new WaitForSeconds(1.5f);
        animator3.SetBool("playerturn", true);
        animator3.SetBool("enemyturn", false);
        Debug.Log("player");
    }
    IEnumerator EnemyTurn()
    {

        yield return new WaitForSeconds(2.5f);
        animator3.SetBool("playerturn", false);
        animator3.SetBool("enemyturn", true);
        Debug.Log("enemy");
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