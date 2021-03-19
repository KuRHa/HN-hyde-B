using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // private int playerHP = 100;  // プレイヤーのHP

    [SerializeField] private int moveSpeed;
    private int maxVectol = 1;
    [SerializeField] private float jumpingPower;    // プレイヤーのジャンプ力

    private Rigidbody _rb;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (isGrounded == true)
        {
            PlayerMove();
            if (Input.GetKey(KeyCode.Space))
            {
                isGrounded = false;
                _rb.AddForce(Vector3.up * jumpingPower);
            }
        }
    }


    // プレイヤーの移動関数
    private void PlayerMove()
    {
        var hori = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");
        var move = new Vector3(hori, 0, vert);



        if (move.magnitude > maxVectol)
        {
            move.Normalize();
        }

        var factor = (moveSpeed * move.magnitude - _rb.velocity.magnitude) / Time.fixedDeltaTime;

        _rb.AddForce(move * factor);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(move), 20 * Time.deltaTime);



        _rb.AddForce(-_rb.velocity / Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}