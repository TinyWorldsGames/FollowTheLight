using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool safeArea;
    public float health;
    public  int level = 1;
    public List<GameObject> levelS;
    public GameObject deneme;

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
