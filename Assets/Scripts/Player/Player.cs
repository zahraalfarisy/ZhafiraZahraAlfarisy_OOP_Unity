using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {get ; private set ; }
    private PlayerMovement playerMovement;
    private Animator animator;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
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
