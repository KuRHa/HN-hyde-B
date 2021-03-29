using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

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

    private int playerMaxHP = 1000;
    public int currentHP;

    public Slider hpSlider;

    [SerializeField] Enemy enemyAttack;
    [SerializeField] BossEnemy bossEnemyAttack;

   // [SerializeField] GameObject _trail;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;

        currentHP = playerMaxHP;

        hpSlider.value = 1;

      //  _trail.SetActive(false);

        animator = GetComponent<Animator>();
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
        if (_velocity.magnitude >= 0.1)
        {
            animator.SetFloat("Walk", _velocity.magnitude);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveCamera.hRotation * _velocity), applySpeed);
            transform.position += moveCamera.hRotation * _velocity;
        }
        else
        {
            animator.SetFloat("Walk", 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(enemyAttack!=null)
            {
                currentHP = currentHP - enemyAttack.attackPower;

                hpSlider.value = (float)currentHP / (float)playerMaxHP;
            }
           
        }

        if (collision.gameObject.tag == "BossEnemy")
        {
                currentHP = currentHP - bossEnemyAttack.bossAttack;

                hpSlider.value = (float)currentHP / (float)playerMaxHP;
        }
    }
}
