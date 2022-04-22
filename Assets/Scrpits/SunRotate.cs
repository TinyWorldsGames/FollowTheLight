using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotate : MonoBehaviour
{
    bool state1=true, state2;
    public float maxZ, minZ;

    Quaternion target;
    void Start()
    {
       
    }

    
    void Update()
    {
        if (state1&&transform.eulerAngles.z>= maxZ)
        {
            target = Quaternion.Euler(0, 0, maxZ);
            state1 = false;
            state2 = true;
    
        }
       
        else if(state2)
        {
            target = Quaternion.Euler(0, 0, minZ);
     
        }

        else if (transform.eulerAngles.z<= minZ)
        {
            target = Quaternion.Euler(0, 0, minZ);
            state2 = false;
            state2 = true;

        }


        Debug.Log(transform.eulerAngles.z);
        


        transform.rotation = Quaternion.Lerp(transform.rotation, target, .05f);
        
        
        
      
    }
}
