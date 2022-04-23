using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotate : MonoBehaviour
{
   
    public float _rotationDegree=0;
    public float _rotationSpeed;
    bool rotation=false;
    public float zDegree;

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
        else if(!rotation && _rotationDegree > -zDegree)
        {
            _rotationDegree -= Time.deltaTime * _rotationSpeed;
            if (_rotationDegree <= -zDegree) { _rotationDegree = -zDegree; rotation = true; }
        }
        transform.rotation = Quaternion.Euler(0, 0, _rotationDegree);
       
        
        
        
      
    }
}
