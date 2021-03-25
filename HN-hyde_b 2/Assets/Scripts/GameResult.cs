using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour
{
    [SerializeField] private playermove playerHP;
    [SerializeField] private BossEnemy bossHP;

    [SerializeField] private GameObject bossEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Result();
    }

    //private void OnEnable()
    //{
    //    Result();
    //}

    void Result()
    {
        if (bossEnemy.activeSelf)
        {
            if (bossHP.currentHP == 0)
            {
                SceneManager.LoadScene("Gameclear");
            }
        }
        

        //if (playerHP.currentHP == 0)
        //{
        //    SceneManager.LoadScene("Gameover");
        //}
    }
}
