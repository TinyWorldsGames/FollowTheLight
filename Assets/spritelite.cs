using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spritelite : MonoBehaviour
{
    public GameObject light;
    public Material mat1,mat2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (light.gameObject.active)
        {
            GetComponent<SpriteRenderer>().material = mat2;
        }
        else
            GetComponent<SpriteRenderer>().material = mat1;

    }
}
