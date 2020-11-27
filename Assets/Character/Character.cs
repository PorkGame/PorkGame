using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private float forwardInput;
    private float rightInput;
    private Vector3 velocity;
    public CameraController cameraController;
    public CharacterMovement characterMovement;
    // private Vector3 velocity, pos;
    // public CharacterMovement characterMovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddMovementInput(float forward, float right) // update movement input
    {
        forwardInput = forward;
        rightInput = right;

        Vector3 camFwd = cameraController.transform.forward;
        Vector3 camRight = cameraController.transform.right;

        Vector3 translation = forward * cameraController.transform.forward;
        translation += right * cameraController.transform.right;

        translation.y = 0;

        if (translation.magnitude > 0)
        {
            velocity = translation;
        }
        else 
        {
            velocity = Vector3.zero;
        }
        characterMovement.Velocity = translation;
    }

    public float getVelocity()
    {
        return velocity.magnitude;
    }
}
