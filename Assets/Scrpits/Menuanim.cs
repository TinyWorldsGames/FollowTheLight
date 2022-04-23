using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menuanim : MonoBehaviour
    
{
    public Animator anim;
    public Player ps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnEnable()
    {
        anim.SetBool("isActive",true);


    }
    public void EndM()
    {

        
        ps.endAnim();
        gameObject.SetActive(false);
    }
}
