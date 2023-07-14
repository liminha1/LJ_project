using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubeproj : MonoBehaviour
{
    private float timer;
    private const float term = 3f;

    public NewBehaviourScript parent;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > term)
        {
            parent.EnQueueCube(this);
            gameObject.SetActive(false);
        }
    }

    public void ResetTimer() => timer = 0f;
}
