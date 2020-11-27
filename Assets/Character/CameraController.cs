using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSmoothingFactor = 1.0f;
    public float lookUpMax = 60;
    public float lookUpMin = -15;

    private Quaternion camRotation;
    // Start is called before the first frame update
    void Start()
    {
        camRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        camRotation.y += Input.GetAxis("Mouse X") * cameraSmoothingFactor;
        camRotation.x += Input.GetAxis("Mouse Y") * -cameraSmoothingFactor;

        camRotation.x = Mathf.Clamp(camRotation.x, lookUpMin, lookUpMax); 

        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
    }
}
