using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;

    void Start()
    {
        // Get the PlayerMovement component and store it in playerMovement
        playerMovement = GetComponent<PlayerMovement>();

        // Find the GameObject containing EngineEffect, get the Animator, and store it
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Call Move method from PlayerMovement
        playerMovement.Move();
    }

    void LateUpdate()
    {
        // Set the "IsMoving" bool parameter based on the return value of IsMoving
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }
}
