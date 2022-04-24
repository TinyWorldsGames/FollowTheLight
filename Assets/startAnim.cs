using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class startAnim : MonoBehaviour
{
    public Text text;
    public GameObject menu;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(text.transform.position.y>= 300.0001)
        {
            text.enabled = false;
            menu.SetActive(true);
            Destroy(gameObject);
        }
        
    }
}
