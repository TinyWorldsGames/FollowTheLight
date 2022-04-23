using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool safeArea, noFireFly;
    public float health;
    public  int level;
    public List<GameObject> levelS;
    public GameObject deneme,torch;
    public int fireFlyCount;
    public SpriteMask spriteMask;
    void Start()
    {
        
    }

 
    void Update()
    {
        spriteMask.alphaCutoff = health / 100;

        if (!safeArea)
        {
            health -= 8 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            levelS[0].SetActive(true);
            deneme.gameObject.SetActive(true);
        }


     
      

        


       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag.Equals("Safearea"))
            safeArea = true;

        
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
        levelS[level - 1].gameObject.SetActive(true);
      

    }
    public void endAnim()
    {
        levelS[level - 1].GetComponent<lights>().OpenLights();
       
    }


}
