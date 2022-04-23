using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void JumpLoop()
    {
        Debug.Log("False yaptým");

        animator.SetBool("isJump", false);
    }
}
