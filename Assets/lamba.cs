using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamba : MonoBehaviour
{

    public bool firefly;
    public GameObject light;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (firefly)
        {
            light.gameObject.SetActive(true);
        }
        if (!firefly)
        {
            light.gameObject.SetActive(false);
        }


    }
    private void OnEnable()
    {
        firefly = false;
        
    }
}
