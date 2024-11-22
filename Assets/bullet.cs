using UnityEditor.TerrainTools;
using UnityEngine;

public class table : MonoBehaviour
{
    public Material live;
    public Material shell;
    public Animator animator;
    public Animator animator2;
    public GameObject[] bullets;
    bool canshow = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        
        
            
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < animator.GetInteger("bullets"); ++i)
        {
            if (animator.GetInteger("live") > i)
            {
                bullets[i].SetActive(true);
                Renderer renderer = bullets[i].GetComponent<Renderer>();
                Material[] materials = renderer.materials;
                materials[0] = live;
                renderer.materials = materials;
            }
            for (int i2 = animator.GetInteger("live"); i2 < animator.GetInteger("bullets"); ++i2)
            {
                bullets[i].SetActive(true);
                Renderer renderer = bullets[i2].GetComponent<Renderer>();
                Material[] materials = renderer.materials;
                materials[0] = shell;
                renderer.materials = materials;


            }
            for (int i3 = animator.GetInteger("bullets"); i3 < 8; i3++)
            {
                bullets[i3].SetActive(false);
            }

        }
    }
    public void Show()
    {
        if (animator2.GetBool("shoot") == false && animator2.GetBool("shoot2") == false && animator2.GetBool("shootself") == false && animator2.GetBool("shootself2") == false)
        {

            for (int i = 0; i < animator.GetInteger("bullets"); ++i)
            {
                if (animator.GetInteger("live")> i)
                {
                    bullets[i].SetActive(true);
                    Renderer renderer = bullets[i].GetComponent<Renderer>();
                    Material[] materials = renderer.materials;
                    materials[0] = live;
                    renderer.materials = materials;
                }
                for (int i2 = animator.GetInteger("live") ; i2 < animator.GetInteger("bullets"); ++i2)
                {
                    bullets[i].SetActive(true);
                    Renderer renderer = bullets[i2].GetComponent<Renderer>();
                    Material[] materials = renderer.materials;
                    materials[0] = shell;
                    renderer.materials = materials;

                }
                for (int i3 = animator.GetInteger("bullets"); i3 < 8; i3++)
                {
                    bullets[i3].SetActive(false);
                }

            }
            
                 
        }
        
    }
}
