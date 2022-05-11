using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public float AngularSpeed = 0;
    public float Speed = 5;

    [SerializeField] private FixedJoystick _joystick;
    private Rigidbody _rigidbody;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //var movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //transform.position += movement * Speed * Time.deltaTime;
        
        // rotation = Quaternion.RotateTowards(
        //     transform.rotation,
        //     rotation,
        //     AngularSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        // movement direction
        var movement = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).normalized;
        if (movement.magnitude < 0.1)
        {
            return;
        }
        _rigidbody.velocity = new Vector3(movement.x, 0, movement.z) * Speed;
        movement.y = 90f;
        
        // rotation relative to the movement direction
        var rotation = Quaternion.LookRotation(movement);
        rotation = Quaternion.RotateTowards(transform.rotation, rotation, AngularSpeed);
        transform.rotation = rotation;
    }
}
