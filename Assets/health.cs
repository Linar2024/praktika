using UnityEngine;

public class health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int health2;
    public Animator animator;
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public GameObject hp4;
    public GameObject hp5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        health2 = animator.GetInteger("health");
        if (health2 > 0)
            hp1.SetActive(true);
        else hp1.SetActive(false);
        if (health2 > 1)
            hp2.SetActive(true);
        else hp2.SetActive(false);
        if (health2 > 2)
            hp3.SetActive(true);
        else hp3.SetActive(false);
        if (health2 > 3)
            hp4.SetActive(true);
        else hp4.SetActive(false);
        if (health2 > 4)
            hp5.SetActive(true);
        else hp5.SetActive(false);
    }
}
