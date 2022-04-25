using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public bool safeArea, noFireFly;
    public float health;
    public int level;
    public List<GameObject> levelS;
    public GameObject deneme, torch, anamenu, restartMenu,levelMenu, healthBarO,lamba,lambaP;
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
            //   animator.SetBool("isDead",true);
            healthBarO.SetActive(false);
            deathMenu();
            transform.position = Vector2.zero;
            levelS[level - 1].GetComponent<lights>().CloseObjects();
            levelS[level - 1].GetComponent<lights>().OpenObjects();

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




        else if (collision.tag.Equals("antiSafe") && !torch.gameObject.active)
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

        if (collision.tag.Equals("final"))
        {
            level = 0;
            anamenu.SetActive(true);
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



        if (collision.tag.Equals("lamp") && fireFlyCount >= 1 && !collision.gameObject.GetComponentInChildren<lamba>().firefly)
        {
           
            fireFlyCount--;
            collision.gameObject.GetComponent<lamba>().firefly = true;
        }

        if (collision.tag.Equals("Firefly"))
        {
            collision.gameObject.SetActive(false);
            fireFlyCount++;
        }


    }
    void levelUp(int level)
    {
        for (int i = 0; i < levelS.Count; i++)
        {
            levelS[i].gameObject.SetActive(false);
        }
        transform.position = new Vector3(-7.17f, -2.84f, -1.17f);
        levelS[level - 1].gameObject.SetActive(true);
        deneme.gameObject.SetActive(true);
        gameObject.SetActive(false);



    }
    public void endAnim()
    {
        levelS[level - 1].GetComponent<lights>().OpenObjects();
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
        animator.SetBool("isDead", false);
        transform.position = new Vector3(-7.17f, -2.84f, -1.17f);

        if (PlayerPrefs.HasKey("level"))
        {
          
            level = (PlayerPrefs.GetInt("level"));
            SelectLevel(level);
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
        levelMenu.SetActive(false);
        restartMenu.SetActive(true);
    }

    public void levelMenuO()
    {
        health = 100;
     
        levelMenu.SetActive(true);
        anamenu.SetActive(false);
         restartMenu.SetActive(false);
       
    }


    public void SelectLevel(int selectedLevel)
    {
        level = selectedLevel;
        PlayerPrefs.SetInt("level", level);
        levelMenu.SetActive(false);
        for (int i = 0; i < levelS.Count; i++)
        {
            levelS[i].gameObject.SetActive(false);
            
            
        }
        transform.position = new Vector3(-7.17f, -2.84f, -1.17f);
        levelS[selectedLevel - 1].gameObject.SetActive(true);
        deneme.gameObject.SetActive(true);
        gameObject.SetActive(false);



    }


}
