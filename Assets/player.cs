using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody rigidBody;
    public Vector3 force;
    public Vector3 moveSpeedRight;

    [HideInInspector]
    public int jumpCount;

    void Start()
    {
        force = new Vector3(0f, 100f, 0f);
        rigidBody = GetComponent<Rigidbody>();
        // GetComponent<Transform>()
        // transform
        // gameObject.transform
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.AddForce(force);
            jumpCount++;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            moveSpeedRight = new Vector3(2f, 0f, 0f);
            transform.Translate(-moveSpeedRight * Time.deltaTime);
            
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            moveSpeedRight = new Vector3(2f, 0f, 0f);
            transform.Translate(moveSpeedRight * Time.deltaTime);
        }    
    }
    
    private void OnCollisionEnter(Collision other) 
    {
            jumpCount = 0;
    }
}
// 이중점프 만들어 보기