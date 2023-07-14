using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniOnOff : MonoBehaviour
{
    public Animator ani;
    private bool toggle = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool("run", toggle);
            toggle = !toggle;
        }
    }
}
