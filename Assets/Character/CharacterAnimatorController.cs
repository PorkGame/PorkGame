using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterAnimatorController : MonoBehaviour
{
    public Animator animator;
    private Character character;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator == null)
        {
            Debug.LogWarning("No Valid Animator");
        }

        animator.SetFloat("Velocity", character.getVelocity());
    }
}
