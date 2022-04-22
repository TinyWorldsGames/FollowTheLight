using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotate : MonoBehaviour
{
    bool state1=true, state2;
    public float maxZ, minZInspector;
    private float minZ;
    public float _rotationDegree=0;
    public float _rotationSpeed;
    public bool rotation = false;

    Quaternion target;
    void Start()
    {
        minZ = 360 + minZInspector;
       
    }

    
    void Update()
{
        if(rotation && _rotationDegree < 30f)
        {
            _rotationDegree += Time.deltaTime * _rotationSpeed;
            if (_rotationDegree >= 30f) { _rotationDegree = 30f; rotation = false; }
        }
        else if(!rotation && _rotationDegree > -30f)
        {
            _rotationDegree -= Time.deltaTime * _rotationSpeed;
            if (_rotationDegree <= -30f) { _rotationDegree = -30f; rotation = true; }
        }
        transform.rotation = Quaternion.Euler(0, 0, _rotationDegree);
       
        
        
        
      
    }
}
