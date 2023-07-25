using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarInput : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector2 moveVector;
    private Car input;

    private const float speed = 700f;
    private const float angularSpeed = 150f;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        input = new Car();
        input.Input.Enable();
        input.Input.Move.performed += Askdg;
        input.Input.Move.canceled += context => moveVector = Vector2.zero;
    }
    
    void FixedUpdate()
    {
        var moveSpeed = moveVector.y * (Time.fixedDeltaTime * speed);
        var angularDegree = moveVector.x * (Time.fixedDeltaTime * angularSpeed);
        _rigidbody.AddForce(transform.forward * moveSpeed);
        _rigidbody.AddTorque(0f, angularDegree, 0f);
        
    }
    
    private void OnMove(InputValue value)
    {
        moveVector = value.Get<Vector2>();
    }

    private void Askdg(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }
}
