using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHit : MonoBehaviour
{
    public Enemy enemtHP;
    public BossEnemy bossHP;
    [SerializeField] playermove attackPower;

    public Slider bossHPSlider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("aaaaa");
            enemtHP.currentHP = enemtHP.currentHP - attackPower.attackPower;
            Debug.Log(enemtHP.currentHP);

            if (enemtHP.currentHP == 0)
            {
                Destroy(other.gameObject);
            }
        }

        if(other.gameObject.tag == "BossEnemy")
        {
            bossHP.currentHP = bossHP.currentHP - attackPower.attackPower;
            bossHPSlider.value = (float)bossHP.currentHP / (float)bossHP.bossHP;
        }

       


    }
}
