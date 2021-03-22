using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private float rotateSpeed;

    [SerializeField] private int cameraDistance;
    private Quaternion vRotation;
    public Quaternion hRotation;
    // Start is called before the first frame update
    void Start()
    {
        vRotation = Quaternion.Euler(30, 0, 0);
        hRotation = Quaternion.identity;

        transform.rotation = hRotation * vRotation;

        transform.position = _player.position - transform.rotation * Vector3.forward * cameraDistance;
    }

    private void LateUpdate()
    {
        hRotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);
        transform.rotation = hRotation * vRotation;
        transform.position = _player.position + new Vector3(0, 3, 0)- transform.rotation * Vector3.forward * cameraDistance;
    }

    // Update is called once per frame
    void Update()
    {
        cameraDistance += (int)Input.GetAxis("Mouse ScrollWheel");
    }
}
