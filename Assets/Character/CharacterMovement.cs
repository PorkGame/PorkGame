using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    public Transform t_Mesh;
    public float maxSpeed = 50f;

    private Vector3 velocity;
    private Rigidbody rigidbody;
    private float rotationSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(velocity);
        rigidbody.velocity = velocity.normalized * maxSpeed;
        
        if (velocity.magnitude > 0)
        {
            t_Mesh.rotation = Quaternion.Lerp(t_Mesh.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * rotationSpeed);
        }
    }

    public Vector3 Velocity { get => velocity; set => velocity = value; }
}
