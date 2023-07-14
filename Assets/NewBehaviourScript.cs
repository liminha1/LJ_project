using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject obj;
    private Queue<Cubeproj> pool;

    private float term = 0.1f;
    private float timer;

    void Start() 
    {
        timer = Time.time;
        pool = new Queue<Cubeproj>();

        for (int i = 0; i < 200; i++)
        {
            var temp = Instantiate(obj);
            temp.SetActive(false);

            var Proj = temp.GetComponent<Cubeproj>();
            Proj.parent = this;
            pool.Enqueue(Proj);
        }
    }

    void Update() 
    {
        if (Time.time - timer < term) return;

        var throwObj = pool.Dequeue();
        throwObj.gameObject.SetActive(true); // 오브젝트 활성화
        throwObj.ResetTimer();              // 타이머 리셋

        var rigid = throwObj.GetComponent<Rigidbody>();
        rigid.AddForce(0f, 800f, 800f);

        timer = Time.time;    
        
    }

    public void EnQueueCube(Cubeproj Proj)
    => pool.Enqueue(Proj);
}
