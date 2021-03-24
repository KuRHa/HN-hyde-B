using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class playermove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float applySpeed;

    private bool _isGround;

    Rigidbody _rb;
    [SerializeField] private MoveCamera moveCamera;

    private Vector3 _velocity;

    public int attackPower = 10;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        _velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _velocity.z += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _velocity.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _velocity.z -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _velocity.x += 1;
        }

        _velocity = _velocity.normalized * moveSpeed * Time.deltaTime;
        if (_velocity.magnitude > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveCamera.hRotation * -_velocity), applySpeed);
            transform.position += moveCamera.hRotation * _velocity;
        }
    }
}