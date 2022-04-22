using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool safeArea;
    public float health;
    void Start()
    {
        
    }

 
    void Update()
    {
        if (!safeArea)
        {
            health -= 2 * Time.deltaTime;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag=="SafeArea")
        safeArea = true;


    }
    private void OnTriggerExit(Collider2D collision)
    {
        if (collision.tag == "SafeArea")
            safeArea = false;
    }

}
