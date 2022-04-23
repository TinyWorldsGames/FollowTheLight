using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool safeArea, noFireFly;
    public float health;
    public  int level;
    public List<GameObject> levelS;
    public GameObject deneme;
    public int fireFlyCount;

    void Start()
    {
        
    }

 
    void Update()
    {
        if (!safeArea)
        {
            health -= 2 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            levelS[2].SetActive(true);
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

          if (collision.tag.Equals("lamp")&&fireFlyCount>=1&&!collision.gameObject.GetComponent<lamba>().firefly)
        {
            fireFlyCount--;
            collision.gameObject.GetComponent<lamba>().firefly = true;
        }

        if (collision.tag.Equals("firefly"))
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
