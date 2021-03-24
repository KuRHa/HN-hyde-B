using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class BossEnemy : MonoBehaviour
{
    private int bossHP = 300;
    private int currentHP;
    public int bossAttack = 30;

    [SerializeField] private playermove playerMove;
    // [SerializeField] private GameObject playerObject;

    private bool isGround = false;

    public Transform playerTarget;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float stopDistance;
    [SerializeField] private float moveDistance;

    public Slider bossHPSlider;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = bossHP;
        bossHPSlider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGround)
        {
            bossenemymove();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            currentHP = currentHP - playerMove.attackPower;
            Debug.Log(currentHP);

            bossHPSlider.value = (float)currentHP / (float)bossHP;

            if(currentHP == 0)
            {
                Destroy(this.gameObject);
            }
        }

        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    private void bossenemymove()
    {
        Vector3 targetPos = playerTarget.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);

        var _distance = Vector3.Distance(transform.position, playerTarget.position);

        if(_distance < moveDistance && _distance > stopDistance)
        {
            transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
