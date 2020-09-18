using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 40f;

    private PlayerController controller;
    private Animator animator;
    private float horizonalMove = 0f;

    private bool jump = false;
    private bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizonalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", UnityEngine.Mathf.Abs(horizonalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        controller.Move(horizonalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
