using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class startAnim : MonoBehaviour
{
    public Text text;
    public Text text2;
    public GameObject menu;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(text.transform.position.y>= 315.0001||Input.anyKey)
        {
            text.enabled = false;
            text2.enabled = false;
            menu.SetActive(true);
            Destroy(gameObject);
        }
        
    }
}
