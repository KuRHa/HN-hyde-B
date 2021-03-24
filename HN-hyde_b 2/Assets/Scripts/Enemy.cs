using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class Enemy : MonoBehaviour
{
    private int maxHP = 100;
    private int currentHP;

    public int attackPower = 10;

    [SerializeField] private playermove playerAttack;
    private GameObject goalPlayer;

    public NavMeshAgent _enemy;

    [SerializeField] private float discoveryDistance;
    private float _distance;

    public Slider enemyHPSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        _enemy = GetComponent<NavMeshAgent>();
        goalPlayer = GameObject.Find("player");

        enemyHPSlider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector3.Distance(transform.position, goalPlayer.transform.position);
        // Debug.Log(_distance);

        if(_distance < discoveryDistance)
        {
            _enemy.destination = goalPlayer.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            currentHP = currentHP - playerAttack.attackPower;
            Debug.Log(currentHP);

            enemyHPSlider.value = (float)currentHP / (float)maxHP;


            if (currentHP == 0)
            {
                Destroy(this.gameObject);
                Debug.Log("aaaaaaaa");
            }
        }
    }
}
