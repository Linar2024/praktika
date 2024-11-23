using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
    public Animator animator;
    public Animator animator2;
    public Animator animator3;
    public Animator animator4;
    public GameObject hide;
    public GameObject unhide;
    public GameObject canvas;
    public GameObject knife;
    public GameObject bear;
    public GameObject part1;
    public GameObject part2;
    public GameObject part3;
    public GameObject bullet;
    public ParticleSystem particle;
    public GameObject rotateobject;
    public AudioSource src;
    public AudioClip sound;
    public AudioClip sound2;
    public Material live2;
    public Material shell2;
    int enemyhealth = 5;
    int health = 5;
    int damage = 1;
    public Button shootenemy;
    int[] bullets = new int[8];
    int bulletscount;
    int currentbullet = 0;
    int live = 0;
    int shell = 0;
    int random = 0;
    int score = 0;
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
        src = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
    }

    // Update is called once per frame
    void Update()
    {
        //if (animator.GetInteger("enemyhealth") <= 0 || animator.GetInteger("health") <= 0)
            //SceneManager.LoadScene("menu");
        if (animator.GetInteger("health") <= 0  )
            animator.SetBool("fulldeath", true);
        if (animator.GetInteger("enemyhealth") <= 0)
            animator4.SetBool("fulldeath", true);
    }
    public void TakeGun()
    {
        if (animator.GetBool("gun") == false && animator.GetBool("can") && animator3.GetBool("playerturn") && animator2.GetBool("showbullets") == false && animator.GetBool("death") == false && animator.GetBool("useknife") == false && animator2.GetBool("getitems") == false && animator.GetBool("usebear") == false)
        {
            //can = false;
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
        if (animator.GetBool("gun") )
        {


            if (animator2.GetInteger("currentlive") < animator2.GetInteger("live") && (animator2.GetInteger("currentshell") < animator2.GetInteger("shell")))
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
                if (animator2.GetInteger("currentshell") < animator2.GetInteger("shell"))
                {
                    bullets[animator2.GetInteger("currentbullet")] = 0;
                    shell++;
                    animator2.SetInteger("currentshell", animator2.GetInteger("currentshell") + 1);
                }
                if (animator2.GetInteger("currentlive") < animator2.GetInteger("live"))
                {
                    bullets[animator2.GetInteger("currentbullet")] = 1;
                    live++;
                    animator2.SetInteger("currentlive", animator2.GetInteger("currentlive") + 1);

                }
            }

            if (bullets[animator2.GetInteger("currentbullet")] == 1 )
            {
                Debug.Log("shoot");
                Debug.Log(bullets[animator2.GetInteger("currentbullet")]);
                currentbullet++;
                animator2.SetInteger("currentbullet", animator2.GetInteger("currentbullet") + 1);
                //bulletscount--;
                //animator2.SetInteger("bullets", bulletscount);
                src.clip = sound;
                src.Play();
                enemyhealth = enemyhealth - 1;
                if (enemyhealth > 0)
                    animator4.SetBool("death", true);
                if (enemyhealth == 0)
                    animator4.SetBool("fulldeath", true);
                score = score + Random.Range(10, 30);
                animator.SetInteger("score", score);
                animator.SetBool("gun", false);
                animator.SetBool("shoot", true);
                animator.SetInteger("enemyhealth", animator.GetInteger("enemyhealth") - animator.GetInteger("damage"));
                damage = 1;
                animator.SetInteger("damage", 1);
                StartCoroutine(EnemyTurn());
                shootenemy.gameObject.SetActive(false);
                
            }

            else if (bullets[animator2.GetInteger("currentbullet")] == 0 )
            {
                Debug.Log("shootshell");
                Debug.Log(bullets[animator2.GetInteger("currentbullet")]);
                currentbullet++;
                animator2.SetInteger("currentbullet", animator2.GetInteger("currentbullet") + 1);
                src.clip = sound2;
                src.Play();
                //bulletscount--;
                animator.SetInteger("damage", 1);
                //animator2.SetInteger("bullets", bulletscount);
                animator.SetBool("gun", false);
                animator.SetBool("shoot2", true);
                StartCoroutine(EnemyTurn());
                shootenemy.gameObject.SetActive(false);
               
            }
            //shootenemy.interactable = false;
            

        }
    }
    public void BulletsCount()
    {
        if (animator2.GetInteger("currentbullet") == animator2.GetInteger("bullets"))
        {
            bulletscount = 0;
            animator2.SetInteger("bullets", bulletscount);
            animator2.SetInteger("currentlive", 0);
            animator2.SetInteger("currentshell", 0);
            animator2.SetInteger("currentbullet", 0);
        }

    }
    public void ShootSelf()
    {

        
        if (animator.GetBool("gun"))
        {
            if (animator2.GetInteger("currentlive") < animator2.GetInteger("live") && (animator2.GetInteger("currentshell") < animator2.GetInteger("shell")))
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
                if (animator2.GetInteger("currentshell") < animator2.GetInteger("shell"))
                {
                    bullets[animator2.GetInteger("currentbullet")] = 0;
                    shell++;
                    animator2.SetInteger("currentshell", animator2.GetInteger("currentshell") + 1);
                }
                if (animator2.GetInteger("currentlive") < animator2.GetInteger("live"))
                {
                    bullets[animator2.GetInteger("currentbullet")] = 1;
                    live++;
                    animator2.SetInteger("currentlive", animator2.GetInteger("currentlive") + 1);

                }
            }


            if (bullets[currentbullet] == 1 )
            {
                Debug.Log("shootself");
                Debug.Log(bullets[currentbullet]);
                currentbullet++;
                animator2.SetInteger("currentbullet", animator2.GetInteger("currentbullet") + 1);
                src.clip = sound;
                src.Play();
                health = health - animator.GetInteger("damage");
                damage = 1;
                animator.SetInteger("damage", 1);
                animator.SetBool("gun", false);
                animator.SetBool("shootself2", true);
                animator.SetInteger("health", health);
                StartCoroutine(EnemyTurn());
                shootenemy.gameObject.SetActive(false);
            }

            else if (bullets[currentbullet] == 0 )
            {
                currentbullet++;
                animator2.SetInteger("currentbullet", animator2.GetInteger("currentbullet") + 1);
                src.clip = sound2;
                src.Play();
                animator.SetBool("can", true);
                animator.SetBool("gun", false);
                animator.SetInteger("damage", 1);
                animator.SetBool("shootself", true);
                StartCoroutine(PlayerTurn());
                shootenemy.gameObject.SetActive(false);
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
    IEnumerator UsingOff()
    {
        animator.SetBool("useknife", false);
        animator.SetInteger("damage", 2);
        yield return new WaitForSeconds(0.01f);

    }
    IEnumerator BearOff()
    {
        animator.SetBool("usebear", false);
        
        yield return new WaitForSeconds(0.01f);

    }
    IEnumerator Skip()
    {


        if (animator2.GetInteger("currentlive") < animator2.GetInteger("live") && (animator2.GetInteger("currentshell") < animator2.GetInteger("shell")))
        {
            bullets[animator2.GetInteger("currentbullet")] = Random.Range(0, 2);
            if (bullets[animator2.GetInteger("currentbullet")] == 1)
            {
                live++;
                animator2.SetInteger("currentlive", animator2.GetInteger("currentlive") + 1);
                animator2.SetInteger("currentbullet", animator2.GetInteger("currentbullet") + 1);
                Renderer renderer = bullet.GetComponent<Renderer>();
                Material[] materials = renderer.materials;
                materials[0] = live2;
                renderer.materials = materials;
            }
            else
            {
                shell++;
                animator2.SetInteger("currentshell", animator2.GetInteger("currentshell") + 1);
                animator2.SetInteger("currentbullet", animator2.GetInteger("currentbullet") + 1);
                Renderer renderer = bullet.GetComponent<Renderer>();
                Material[] materials = renderer.materials;
                materials[0] = shell2;
                renderer.materials = materials;
            }
        }
        else
        {
            if (animator2.GetInteger("currentshell") < animator2.GetInteger("shell"))
            {
                bullets[animator2.GetInteger("currentbullet")] = 0;
                shell++;
                animator2.SetInteger("currentbullet", animator2.GetInteger("currentbullet") + 1);
                Renderer renderer = bullet.GetComponent<Renderer>();
                Material[] materials = renderer.materials;
                materials[0] = shell2;
                renderer.materials = materials;
                animator2.SetInteger("currentshell", animator2.GetInteger("currentshell") + 1);
            }
            if (animator2.GetInteger("currentlive") < animator2.GetInteger("live"))
            {
                bullets[animator2.GetInteger("currentbullet")] = 1;
                live++;
                animator2.SetInteger("currentbullet", animator2.GetInteger("currentbullet") + 1);
                Renderer renderer = bullet.GetComponent<Renderer>();
                Material[] materials = renderer.materials;
                materials[0] = live2;
                renderer.materials = materials;
                animator2.SetInteger("currentlive", animator2.GetInteger("currentlive") + 1);

            }
        }
        if (animator2.GetInteger("currentbullet") == animator2.GetInteger("bullets"))
        {
            bulletscount = 0;
            animator2.SetInteger("bullets", bulletscount);
            animator2.SetInteger("currentlive", 0);
            animator2.SetInteger("currentshell", 0);
            animator2.SetInteger("currentbullet", 0);
        }
        yield return new WaitForSeconds(0.01f);

    }
    IEnumerator PlayerTurn()
    {
        
        yield return new WaitForSeconds(2.5f);
        animator3.SetBool("playerturn", true);
        animator3.SetBool("enemyturn", false);
        Debug.Log("player");
    }
    IEnumerator DeathOFf()
    {

        yield return new WaitForSeconds(0.01f);
        animator.SetBool("death", false);
    }
    IEnumerator EnemyTurn()
    {
        animator.SetBool("can", false);
        yield return new WaitForSeconds(1.5f);
        animator3.SetBool("playerturn", false);
        animator3.SetBool("enemyturn", true);
        Debug.Log("enemy");
        animator4.SetBool("can", true);
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
    IEnumerator KnifeOn()
    {
        knife.SetActive(true);
        yield return new WaitForSeconds(0.01f);

    }
    IEnumerator Used()
    {
        part1.SetActive(false);
        part2.SetActive(false);
        part3.SetActive(false);
        yield return new WaitForSeconds(0.01f);

    }
    IEnumerator UsedOff()
    {
        part1.SetActive(true);
        part2.SetActive(true);
        part3.SetActive(true);
        yield return new WaitForSeconds(0.01f);

    }
    IEnumerator KnifeOff()
    {
        knife.SetActive(false);
        yield return new WaitForSeconds(0.01f);

    }
    IEnumerator BearOf()
    {
        bear.SetActive(false);
        yield return new WaitForSeconds(0.01f);

    }

    IEnumerator BearOn()
    {
        bear.SetActive(true);
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
