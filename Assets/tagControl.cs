using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tagControl : MonoBehaviour
{
    public GameObject level;

    void Start()
    {
        
    }

    
    void Update()
    {
      
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player")&&!collision.gameObject.GetComponent<Player>().torch.gameObject.active)
        {
            Debug.Log(collision.gameObject.GetComponent<Player>().torch.gameObject.active);

            for (int i = 0; i < level.gameObject.GetComponent<lights>().lightsL.Length; i++)
            {
                level.gameObject.GetComponent<lights>().lightsL[i].tag = "empty";
            }
        }
        
          
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < level.gameObject.GetComponent<lights>().lightsL.Length; i++)
        {
            level.gameObject.GetComponent<lights>().lightsL[i].tag = "Safearea";
        }
    }



}
