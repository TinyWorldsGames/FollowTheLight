using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public bool safeArea, noFireFly;
    public float health;
    public  int level;
    public List<GameObject> levelS;
    public GameObject deneme,torch,anamenu,restartMenu,healthBarO;
    public int fireFlyCount;
    public Image healthBar;
     Animator animator;
   // public SpriteMask spriteMask;
   // public Image blood;
   
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
       
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }

        // spriteMask.alphaCutoff = health / 100;
        if (health >= 100)
            health = 100;

        healthBar.fillAmount = health / 100;

        if (!safeArea)
        {
            health -= 30 * Time.deltaTime;
        }
        else
        {
            health += 10 * Time.deltaTime;
        }

       


        if (health <= 0)
        {
            animator.SetBool("isDead",true);
            healthBarO.SetActive(false);
        }




        if (torch.active)
        {
            safeArea = true;
        }






      


     
      

        


       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag.Equals("Safearea"))
        {
            safeArea = true;
        } 

    else  if (collision.tag.Equals("antiSafe")&&!torch.gameObject.active)
        {
            safeArea = false;


        }
      


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Safearea"))
            safeArea = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("LevelPoint"))
        {
            level++;
            PlayerPrefs.SetInt("level", level);
            levelUp(level);
          
        }

        if (collision.tag.Equals("torch"))
        {
           
            Destroy(collision.gameObject);
            torch.SetActive(true);

        }

        if (collision.tag.Equals("button"))
        {
            collision.gameObject.GetComponent<Animator>().enabled = true;
            collision.gameObject.GetComponent<DoorM>().openDoor();
        }



        if (collision.tag.Equals("lamp")&&fireFlyCount>=1&&!collision.gameObject.GetComponentInChildren<lamba>().firefly)
        {
            Debug.Log("lamba");
            fireFlyCount--;
            collision.gameObject.GetComponent<lamba>().firefly = true;
        }

        if (collision.tag.Equals("Firefly"))
        {
            Destroy(collision.gameObject);
            fireFlyCount++;
        }


    }
    void levelUp(int level)
    {
        for (int i = 0; i < level; i++)
        {
            levelS[i].gameObject.SetActive(false);
        }
        transform.position = new Vector3(-7.17f,-2.84f,-1.17f);
        levelS[level - 1].gameObject.SetActive(true);
        deneme.gameObject.SetActive(true);
        gameObject.SetActive(false);
      


    }
    public void endAnim()
    {
        levelS[level - 1].GetComponent<lights>().OpenLights();
       
    }

    public void StartTheGame()
    {
        Debug.Log(PlayerPrefs.HasKey("level"));
        if (PlayerPrefs.HasKey("level"))
        {
            levelUp(PlayerPrefs.GetInt("level"));
            level = (PlayerPrefs.GetInt("level"));
            Debug.Log(PlayerPrefs.GetInt("level"));
        }
        else
        {
            levelUp(1);
        }
       
        deneme.gameObject.SetActive(true);
        anamenu.SetActive(false);

    }

    public void RestartTheGame()
    {
        health = 100;
        animator.SetBool("isDead",false);
        transform.position = new Vector3(-7.17f, -2.84f, -1.17f);

        if (PlayerPrefs.HasKey("level"))
        {
            levelUp(PlayerPrefs.GetInt("level"));
            level = (PlayerPrefs.GetInt("level"));
            Debug.Log(PlayerPrefs.GetInt("level"));
        }
        else
        {
            levelUp(1);
        }

        deneme.gameObject.SetActive(true);
        restartMenu.SetActive(false);

    }
    public void deathMenu()
    {
        restartMenu.SetActive(true);
    }



}
