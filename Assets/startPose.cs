using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPose : MonoBehaviour
{
    public float startDegree;
    
   

   
    private void OnEnable()
    {
        GetComponentInChildren<SunRotate>()._rotationDegree = startDegree;
    }
}

