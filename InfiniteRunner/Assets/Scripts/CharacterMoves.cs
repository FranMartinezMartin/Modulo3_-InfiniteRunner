using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMoves : MonoBehaviour
{
    Rigidbody rb;
    Vector3 movementDir;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float speed = 5f;
    [SerializeField] float turnVelocity = 720f;
    Animator animator;
    [SerializeField] bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementDir = new Vector3(horizontal,0f,vertical).normalized;
        
        if(movementDir.magnitude >= 0.1f)
        {
            walking(true);
            transform.Translate(movementDir*speed*Time.deltaTime, Space.World);
            Quaternion toRotation = Quaternion.LookRotation(movementDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnVelocity*Time.deltaTime);
        } else{
            walking(false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            jumping(true);
            StartCoroutine(jump());
        }
    }

    private void FixedUpdate() {
        GroundCheck();
    }

    void walking(bool state) {        
        animator.SetBool("isWalking", state);
    }
    void jumping(bool state) {        
        animator.SetBool("isJumping", state);   
    }
    void running(bool state) {        
        animator.SetBool("isRunning", state);    
    }

    private IEnumerator jump(){
        yield return new WaitForSeconds(0.5f);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        yield return new WaitForSeconds(1f);
        jumping(false);
    }

    void GroundCheck()
    {
        Ray ray = new Ray(transform.position, new Vector3(0,-0.2f,0));
        if(Physics.Raycast(ray, 0.2f)){
            isGrounded=true;
        } else {
            isGrounded = false;
        };
    }
}
