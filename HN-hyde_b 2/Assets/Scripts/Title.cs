using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    void Update()
    {
        //�}�E�X�̍��N���b�N����������
        if (Input.GetMouseButtonDown(0))
        {
            //��ʂ��P�ԖڂɑJ�ڂ���i�ς���j
            SceneManager.LoadScene(1);
        }
    }
}

