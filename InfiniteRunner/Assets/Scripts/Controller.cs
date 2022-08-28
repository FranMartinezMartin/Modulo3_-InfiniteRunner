using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Animator animator;
    CharacterController cc;

    float movementSpeed;
    bool isWalking = false;


    
    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        movementSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.W))        {
            walking(true);     
            movementDirection.z = 1;      
        }else if(Input.GetKeyDown(KeyCode.S)){
            walking(true);     
            movementDirection.z = -1; 
        }else if(Input.GetKeyDown(KeyCode.A)){
            walking(true);     
            movementDirection.x = -1; 
        }else if(Input.GetKeyDown(KeyCode.D)){
            walking(true);     
            movementDirection.x = 1; 
        }else if(Input.GetKeyDown(KeyCode.Space)){
            walking(true);     
            movementDirection.y = 1; 
        }

        Move(movementDirection);
    }

    void Move(Vector3 direction) {
        cc.SimpleMove(direction.normalized * movementSpeed);
    }
    void walking(bool state){
        animator.SetBool("isWalking", state);
    }
}
