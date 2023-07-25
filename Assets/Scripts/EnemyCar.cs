using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

public class EnemyCar : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private Vector2 moveVector;

    private float AngleWithCar = 0;

    private Transform target;

    private float moveSpeed = 0f;
    private float angularDegree = 0f; 
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        StartCoroutine(FindCar());
    }
    
    void FixedUpdate()
    {
        ForceOfCar();
    }
    
    private IEnumerator FindCar()
    {
        float minValue = float.MaxValue;
        
        foreach (var trans in EssManager.CountCar)
        {
            float dist = Vector3.Distance(trans.position, transform.position);
            if(dist < 4f) continue;
            if (minValue > dist)
            {
                minValue = dist;
                target = trans;
            }
        }
        
        yield return new WaitForSeconds(3f);
    }
    
    
     private void ForceOfCar()
    {
        // 제일 가까운 차 위치 => target
        var transform1 = transform;
        AngleWithCar = Vector3.SignedAngle( target.position - transform1.position, -transform1.forward, Vector3.up);

        // moveSpeed 와 AngleWithCar는 반비례 관계
        moveSpeed = 20f - AngleWithCar * 0.01f + Random.Range(-10f, 10f);
        angularDegree = AngleWithCar + Random.Range(-10f, 10f);

        // AddForce, AddTorque 실행
        _rigidbody.AddTorque(0f, -angularDegree, 0f);
        _rigidbody.AddForce(-(transform.forward * moveSpeed));

        
    }
    
}
