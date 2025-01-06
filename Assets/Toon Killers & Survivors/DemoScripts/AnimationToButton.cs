using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationToButton : MonoBehaviour
{
    public AIController aiController;
    Animator anim;
    public CharacterController characterController; // Assuming you're using a CharacterController for movement

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>(); // Assuming your character has a CharacterController
        RuntimeAnimatorController rac = anim.runtimeAnimatorController;
        aiController = GetComponent<AIController>();
    }

    void Update()
    {
        bool patrol = aiController.m_IsPatrol;
        // Check if the object is moving
        bool isMoving = characterController.velocity.magnitude > 0.1f;

        // Set the "IsChasing" parameter in the Animator
        anim.SetBool("IsPatrolling", patrol);
    }

    
}
