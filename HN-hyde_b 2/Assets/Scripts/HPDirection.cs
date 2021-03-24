using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDirection : MonoBehaviour
{
    public Canvas hpCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpCanvas.transform.rotation = Camera.main.transform.rotation;
    }
}
