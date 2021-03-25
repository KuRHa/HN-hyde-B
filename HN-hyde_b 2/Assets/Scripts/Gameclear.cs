using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameclear : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Gameclear");
    }

    // Update is called once per frame
    void Update()
    {

    }
}