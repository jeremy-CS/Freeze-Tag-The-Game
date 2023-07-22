using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Movement variables
    [SerializeField] float rotationSpeed = 65f;
    [SerializeField] AIAgent ogChaser;

    //Token variable
    public int tokenCounter = 0;

    //Game reference
    [SerializeField] private UIChanges game;

    //Movement variables
    private CharacterController characterController;
    [SerializeField] private Transform cameraTransform;
    
    //Animator variables
    private Animator animator;
    private bool isRunning = false;
    private bool isWalking = false;
    private bool isStanding = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update Animator
        UpdateAnimator();

        //convert user input into world movement
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        //assign movement to a vector3
        Vector3 movementDirection = new Vector3(horizontalMovement, 0, verticalMovement);
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        //If shift is pressed, run, otherwise walk
        if (movementDirection != Vector3.zero)
        {
            isStanding = false;

            //apply rotation to player
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRunning = true;
                isWalking = false;
            }
            else
            {
                isRunning = false;
                isWalking = true;
            }
        }
        else
        {
            isRunning = false;
            isWalking = false;
            isStanding = true;
        }        
    }

    private void OnAnimatorMove()
    {
        Vector3 velocity = animator.deltaPosition;

        characterController.Move(velocity);
    }

    //Updating animator
    public void UpdateAnimator()
    {
        animator.SetBool("walking", isWalking);
        animator.SetBool("running", isRunning);
        animator.SetBool("standing", isStanding);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Token")
        {
            tokenCounter++;
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.tag == "Chaser")
        {
            game.EndGame(true);
        }
    }
}
