using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator anim;
    CharacterController characterController;
    public float speed = 4.0f;
    public float rotateSpeed = 3f;
    public float jumpForce = 5f;
    public float gravity = -9.8f;
    Vector3 inputVec;
    Vector3 tragetDirection;
    private Vector3 moveDirection = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = -(Input.GetAxisRaw("Vertical"));
        float z = (Input.GetAxisRaw("Horizontal"));
        inputVec = new Vector3(x, 0, z);

        anim.SetFloat("Input X", z);
        anim.SetFloat("Input Z", -(x));

        if (x != 0 || z != 0)
        {

            anim.SetBool("Running", true);
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Running", false);
            anim.SetBool("Moving", false);
        }

        // Jumping
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                anim.SetBool("Jumping", true);
                moveDirection.y = jumpForce;
            }
            else
            {
                anim.SetBool("Jumping", false);
                anim.SetBool("Running", moveDirection.magnitude > 0.0f);
            }
        }
        characterController.Move(moveDirection * Time.deltaTime);

        UpdateMovement();
    }

    void UpdateMovement()
    {
        Vector3 motion = inputVec;
        motion *= (Mathf.Abs(inputVec.x) == 1 && Mathf.Abs(inputVec.z) == 1) ? .7f : 1;

        RotateTowardMovementDirection();
        getCameraRealtive();
    }

    void RotateTowardMovementDirection()
    {
        if (inputVec != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tragetDirection), Time.deltaTime * rotateSpeed);
        }
    }

    void getCameraRealtive()
    {
        Transform cameraTranform = Camera.main.transform;
        Vector3 forward = cameraTranform.TransformDirection(Vector3.forward);
        forward.y = 0;
        forward = forward.normalized;

        Vector3 right = new Vector3(forward.z, 0, -forward.x);
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        tragetDirection = (h * right) + (v * forward);
    }
}
