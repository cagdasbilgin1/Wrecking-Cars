using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float moveSpeedWhileTurning = 10f;
    [SerializeField] float turnSpeed = 300f;
    float currentMoveSpeed;
    float moverInput;
    float turnerInput;
    bool groundTouch;

    void Update()
    {        
        MovePlayerInput();
        TurnPlayerInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
        TurnPlayer();
    }

    void MovePlayerInput()
    {
        if (groundTouch)
        {
            HandleMoveSpeed();
            moverInput = Input.GetAxis("Vertical") * currentMoveSpeed;
        }
    }
    void TurnPlayerInput()
    {
        if (groundTouch)
        {
            turnerInput = Input.GetAxisRaw("Horizontal") * turnSpeed * Input.GetAxisRaw("Vertical");
        }
    }

    void MovePlayer()
    {
        moverInput *= Time.fixedDeltaTime;
        transform.Translate(0, 0, moverInput);
    }    

    void TurnPlayer()
    {
        turnerInput *= Time.fixedDeltaTime;
        transform.Rotate(0, turnerInput, 0);
    }

    void HandleMoveSpeed() //if the car is turning, reduce its moveSpeed
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            currentMoveSpeed = moveSpeedWhileTurning;
        }
        else
        {
            currentMoveSpeed = moveSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            groundTouch = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            groundTouch = false;
        }
    }

}
