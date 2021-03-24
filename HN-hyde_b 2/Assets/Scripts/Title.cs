using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    void Update()
    {
        //マウスの左クリックを押したら
        if (Input.GetMouseButtonDown(0))
        {
            //画面を１番目に遷移する（変える）
            SceneManager.LoadScene(1);
        }
    }
}

