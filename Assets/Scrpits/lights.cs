using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lights : MonoBehaviour
{
    public GameObject[] lightsL, Openobjects,Closeobjects;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenLights()
    {
        for (int i = 0; i < lightsL.Length; i++)
        {
            lightsL[i].gameObject.SetActive(true);
          
        }
    }
   public void OpenObjects()

    {
        for (int i = 0; i < Openobjects.Length; i++)
        {

            Openobjects[i].gameObject.SetActive(true);

            
        }


     
    }
    public void CloseObjects()

    {
        for (int i = 0; i < Closeobjects.Length; i++)
        {

            Closeobjects[i].gameObject.SetActive(false);


        }



    }

}
