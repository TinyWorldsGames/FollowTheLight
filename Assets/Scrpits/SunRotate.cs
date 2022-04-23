using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotate : MonoBehaviour
{
   
    public float _rotationDegree=0;
    public float _rotationSpeed;
    bool rotation = true;
    public float zDegree, zDegreeN;
    public bool flipflopp;
    public Animator animator;

    void Start()
    {
        if (_rotationDegree < 0)
        {
            rotation = true;
        }
        if (_rotationDegree > 0)
        {
            rotation = false;
        }


    }

    
    void Update()
{
        if(rotation && _rotationDegree < zDegree)
        {
            _rotationDegree += Time.deltaTime * _rotationSpeed;
            if (_rotationDegree >= zDegree) { _rotationDegree = zDegree; rotation = false; }
        }
        else if(!rotation && _rotationDegree > -zDegreeN)
        {
            _rotationDegree -= Time.deltaTime * _rotationSpeed;
            if (_rotationDegree <= -zDegreeN) { _rotationDegree = -zDegreeN; rotation = true; }
        }
        transform.localRotation = Quaternion.Euler(0, 0, _rotationDegree);

        if (flipflopp)
        {
            animator.SetBool("isActive",true);

        }
        
        
      
    }
}
