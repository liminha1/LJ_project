using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    public Animator ani;

    void start()
    {

    }

    public void SliderSpeed(float speed)
    {
        ani.SetFloat("speed", speed);
    }
}
