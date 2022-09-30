using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Animator animator;
    CharacterController cc;

    float movementSpeed;
    bool isWalking = false;

    float turnSmooth = 0.1f;
    float turnVelocity;

    Rigidbody rb;
    float jumpForce = 5f;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        movementSpeed = 5f;
        rb = GetComponent<Rigidbody>();
    }
/*
    void Update()
    {
        Vector3 movementDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))        {
            walking(true);     
            movementDirection.z = 1;  
            transform.rotation = Quaternion.Euler(new Vector3(0f,0f,0f));
        }
        else if(Input.GetKey(KeyCode.S)){
            walking(true);     
            movementDirection.z = -1;
            transform.rotation = Quaternion.Euler(new Vector3(0f,180f,0f));
        }
        else if(Input.GetKey(KeyCode.A)){
            walking(true);     
            movementDirection.x = -1;
            transform.rotation = Quaternion.Euler(new Vector3(0f,-90f,0f)); 
        }
        else if(Input.GetKey(KeyCode.D)){
            walking(true);     
            movementDirection.x = 1;
            transform.rotation = Quaternion.Euler(new Vector3(0f,90f,0f)); 
        }
        else if(Input.GetKey(KeyCode.Space)){
            walking(true);     
            movementDirection.y = 1; 
        }
        else {
            walking(false);
        }

        Move(movementDirection);
    }
*/

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal,0f,vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            walking(true);
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnVelocity, turnSmooth);
            transform.rotation = Quaternion.Euler(0f,angle,0f);
            cc.Move(direction.normalized * movementSpeed * Time.deltaTime);
        } else {
            walking(false);
        }

        if(Input.GetButtonDown("Jump"))
        {
            jumping(true);
        }else {
           jumping(false);
        }
    }

    void walking(bool state){
        animator.SetBool("isWalking", state);
    }

    void jumping(bool state){
        animator.SetBool("isJumping", state);
        if (state)
        {
            cc.Move(new Vector3(0, jumpForce, 0));
        }
        
    }

    void running(bool state) {
        animator.SetBool("isRunning", state);
    }

}
