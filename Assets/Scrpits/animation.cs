using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public Animator animator;
    public Player playerS;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void JumpLoop()
    {
       
        animator.SetBool("isJump", false);
    }
    public void Restart()
    {
        animator.SetBool("isDead", false);
        playerS.deathMenu();

}
}
