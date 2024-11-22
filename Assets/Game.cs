using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Game : MonoBehaviour
{
    public Animator animator;
    public Animator animator2;
    bool canrandom = true;
    bool startgame = true;
    public GameObject knife1;
    public GameObject knife2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Show());
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetInteger("bullets") <= 0 && animator.GetBool("showbullets") == false)
        {
            StartCoroutine(Show());
        }


    }
    public void ShowBullets()
    {
        int bullets = Random.Range(2, 9);
        int live = Random.Range(1, (bullets) - 1);
        int shell = bullets - live;
        Debug.Log(live);
        Debug.Log(shell);
        animator.SetInteger("bullets", bullets);
        animator.SetInteger("live", live);
        animator.SetInteger("shell", shell);
        animator.SetBool("showbullets", true);
        animator2.SetBool("showbullets", true);



    }
    IEnumerator Show()
    {
        
        yield return new WaitForSeconds(1.5f);
        if (animator.GetInteger("bullets") <= 0 && animator.GetBool("showbullets") == false)
        {
            ShowBullets();
        }
           
        if (startgame == true)
        {
            //startgame = false;
            StartCoroutine(GetItems());
        }
    }
    IEnumerator GetItems()
    {

        yield return new WaitForSeconds(6f);
        animator.SetBool("getitems", true);
        yield return new WaitForSeconds(2.3f);
        knife1.SetActive(true);
        knife2.SetActive(true);

    }
    IEnumerator FalseGet()
    {
        animator.SetBool("getitems", false);

        yield return new WaitForSeconds(0f);
        animator2.SetBool("can", true);

    }
    IEnumerator FalseShow()
    {
        animator.SetBool("showbullets", false);
        animator2.SetBool("showbullets", false);
        yield return new WaitForSeconds(0.1f);
        
    }

}
