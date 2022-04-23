using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lights : MonoBehaviour
{
    public GameObject[] lightsL;
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
}
