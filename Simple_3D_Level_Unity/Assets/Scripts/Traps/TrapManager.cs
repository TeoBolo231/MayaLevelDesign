using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public bool trapsActive = true;
    public GameObject platform1;
    public GameObject plarform2;
    public GameObject platform3;
    public GameObject ball1;
    public GameObject ball2;
    public GameObject boulder;
    public GameObject skipPlatform;

    private Rigidbody rbPlat1;
    private Rigidbody rbPlat2;
    private Rigidbody rbPlat3;
    private Rigidbody rbBall1;
    private Rigidbody rbBall2;
    private Rigidbody rbBoulder;

    private bool plat1Active = false;
    private bool plat2Active = false;
    private bool plat3Active = false;
    private bool ball1Active = false;
    private bool ball2Active = false;
    private bool boulderActive = false;

    private float boulderForce = 5000f;
    private Vector3 angleVelocity1;
    private Vector3 angleVelocity2;
    private float ball1Delay = 1f;

    private void Awake()
    {
        rbPlat1 = platform1.GetComponent<Rigidbody>();
        rbPlat2 = plarform2.GetComponent<Rigidbody>();
        rbPlat3 = platform3.GetComponent<Rigidbody>();
        rbBall1 = ball1.GetComponent<Rigidbody>();
        rbBall2 = ball2.GetComponent<Rigidbody>();
        rbBoulder = boulder.GetComponent<Rigidbody>();
        
        rbPlat1.constraints = RigidbodyConstraints.FreezeAll;
        rbPlat2.constraints = RigidbodyConstraints.FreezeAll;
        rbPlat3.constraints = RigidbodyConstraints.FreezeAll;

        angleVelocity1 = new Vector3(120, 0, 0);
        angleVelocity2 = new Vector3(120, 0, 0);
        skipPlatform.SetActive(!trapsActive); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            trapsActive = !trapsActive;
            skipPlatform.SetActive(!trapsActive);
        }

        if (trapsActive)
        {
            if (plat1Active)
            {
                rbPlat1.constraints = ~RigidbodyConstraints.FreezePositionY;
            }

            if (plat2Active)
            {
                rbPlat2.constraints = ~RigidbodyConstraints.FreezePositionY;
            }

            if (plat3Active)
            {
                rbPlat3.constraints = ~RigidbodyConstraints.FreezePositionY;
            }

            if (ball1Active)
            {
                Quaternion deltaRotation1 = Quaternion.Euler(angleVelocity1 * Time.deltaTime);
                rbBall1.MoveRotation(rbBall1.rotation * deltaRotation1);
                StartCoroutine(BallStop1(rbBall1));
            }

            if (ball2Active)
            {
                Quaternion deltaRotation2 = Quaternion.Euler(angleVelocity2 * Time.deltaTime);
                rbBall2.MoveRotation(rbBall2.rotation * deltaRotation2);
                StartCoroutine(BallStop2(rbBall2));
            }

            if (boulderActive)
            {
                rbBoulder.AddForce(-transform.right * boulderForce * Time.deltaTime);
            }
        } 
    }

    IEnumerator BallStop1(Rigidbody rb)
    {
        yield return new WaitForSeconds(ball1Delay);
        angleVelocity1 = new Vector3(0, 0, 0);
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    IEnumerator BallStop2(Rigidbody rb)
    {
        yield return new WaitForSeconds(ball1Delay);
        angleVelocity2 = new Vector3(0, 0, 0);
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void StartPlat1(bool state)
    {
        plat1Active = state;
    }
    public void StartPlat2(bool state)
    {
        plat2Active = state;
    }
    public void StartPlat3(bool state)
    {
        plat3Active = state;
    }
    public void StartBall1(bool state)
    {
        ball1Active = state;
    }
    public void StartBall2(bool state)
    {
        ball2Active = state;
    }
    public void StartBoulder(bool state)
    {
        boulderActive = state;
    }
}
