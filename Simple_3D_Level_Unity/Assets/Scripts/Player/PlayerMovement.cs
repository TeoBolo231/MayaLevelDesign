using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public HashIDs hashID;
    public Rigidbody myRigidBody;
    public Text winText;
    public Text deadText;
    public Image textBG;
    private Animator anim;

    public bool grounded;
    private bool jumpButton;
    private bool sprintButton;
    private float moveX;
    private float moveY;
    public float moveForce = 100f;
    public float jumpForce = 150f;
    public float sprintForce = 1.2f;
    public float turnSpeed = 4f;

    private bool win = false;
    private bool alive = true;
    public bool cinematic = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody>();
        textBG.enabled = false;
        deadText.enabled = false;
        winText.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        moveX = Input.GetAxis("Vertical");
        moveY = Input.GetAxis("Horizontal");
        jumpButton = Input.GetButtonDown("Jump");
        sprintButton = Input.GetButton("Sprint");

        if (alive && !cinematic && !win)
        {
            MovementManager(moveX, moveY);
            Jump();
        }
        if (!alive)
        {
            deadText.enabled = true;
            textBG.enabled = true;
            DisableAnimations();
            anim.SetBool(hashID.deadBool, true);
        }
        if (win)
        {
            winText.enabled = true;
            textBG.enabled = true;
            DisableAnimations();
        }
    }

    void MovementManager(float vertical, float horizontal)
    {
        if (vertical == 0)
        {
            transform.Rotate(horizontal * turnSpeed * Vector3.up, Space.World);
        }

        if (vertical > 0)
        {
            transform.Rotate(horizontal * turnSpeed * Vector3.up, Space.World);

            myRigidBody.AddForce(moveForce * transform.forward);
            anim.SetFloat(hashID.speedFloat, vertical);
            if (sprintButton)
            {
                myRigidBody.AddForce(moveForce * transform.forward * sprintForce);
                anim.SetBool(hashID.sprintBool, true);
            }
            else
            {
                anim.SetBool(hashID.sprintBool, false);
            }
        }

        if (vertical < 0)
        {
            if (horizontal > 0)
            {
                myRigidBody.AddForce(moveForce * transform.right);
            }

            if (horizontal < 0)
            {
                myRigidBody.AddForce(moveForce * -transform.right);
            }

            myRigidBody.AddForce(moveForce * -transform.forward);
            anim.SetFloat(hashID.speedFloat, vertical);
        }
    }

    private void Jump()
    {
        if (grounded && jumpButton)
        {
            anim.SetBool(hashID.jumpBool, true);
            myRigidBody.AddForce(jumpForce * Vector3.up);
        }
        else
        {
            anim.SetBool(hashID.jumpBool, false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            grounded = !grounded;
            print("Grounded: " + grounded);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            grounded = !grounded;
            print("Grounded: " + grounded);
        }
    }

    public void Win(bool state)
    {
        win = state;
    }

    public void Dead(bool dead)
    {
        if (dead)
        {
            alive = false;
        }
    }
    
    public void Cinematic(bool state)
    {
        cinematic = state;
    }

    public void DisableAnimations()
    {
        anim.SetBool(hashID.jumpBool, false);
        anim.SetBool(hashID.sprintBool, false);
        anim.SetFloat(hashID.speedFloat, 0f);
    }

    public void SparksAnim(bool state)
    {
        anim.SetBool(hashID.sparksBool, state);
    }
    //public void PickUpAnim(bool state)
    //{
    //    anim.SetBool(hashID.pickBool, state);
    //}
    public IEnumerator PickUpAnimCol()
    {
        DisableAnimations();
        Cinematic(true);
        anim.SetBool(hashID.pickUpCol, true);
        yield return new WaitForSecondsRealtime(3f);
        anim.SetBool(hashID.pickUpCol, false);
        Cinematic(false);
    }
    public IEnumerator PickUpAnimTer()
    {
        DisableAnimations();
        Cinematic(true);
        anim.SetBool(hashID.pickUpTer, true);
        yield return new WaitForSecondsRealtime(2.5f);
        anim.SetBool(hashID.pickUpTer, false);
        Cinematic(false);
    }
}






