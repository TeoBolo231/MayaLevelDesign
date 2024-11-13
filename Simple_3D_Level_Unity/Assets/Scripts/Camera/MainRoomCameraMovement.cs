using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoomCameraMovement : MonoBehaviour
{
    private float speed = 3f;
    //private float maxSpeed = 20f;

    public Transform[] cameraPositions;
    private Transform currentPos;
    private Transform quad0Pos;
    private Transform quad1Pos;
    private Transform quad2Pos;
    private Transform quad3Pos;
    private Transform fusePos;
    private Transform terminalPos;
    private Transform cinematicPos1;
    private Transform cinematicPos2;
    private Transform cinematicPos3;
    private Transform cinematicPos4;
    private Transform cinematicPos5;
    private Transform cinematicPos6;

    private bool quad0;
    private bool quad1;
    private bool quad2;
    private bool quad3;
    private bool fuse;
    private bool terminal;
    private bool cinematic1;
    private bool cinematic2;
    private bool cinematic3;
    private bool cinematic4;
    private bool cinematic5;
    private bool cinematic6;

    private void Awake()
    {
        quad0Pos = cameraPositions[0];
        quad1Pos = cameraPositions[1];
        quad2Pos = cameraPositions[2];
        quad3Pos = cameraPositions[3];
        fusePos = cameraPositions[4];
        terminalPos = cameraPositions[5];
        cinematicPos1 = cameraPositions[6];
        cinematicPos2 = cameraPositions[7];
        cinematicPos3 = cameraPositions[8];
        cinematicPos4 = cameraPositions[9];
        cinematicPos5 = cameraPositions[10];
        cinematicPos6 = cameraPositions[11];
        currentPos = quad0Pos;
    }

    private void Update()
    {
        if (quad0)
        {
            if (terminal)
            {
                if (cinematic1)
                {
                    currentPos = cinematicPos1;
                }
                else if (cinematic2)
                {
                    currentPos = cinematicPos2;
                }
                else if (cinematic3)
                {
                    currentPos = cinematicPos3;
                }
                else if (cinematic4)
                {
                    currentPos = cinematicPos4;
                }
                else if (cinematic5)
                {
                    currentPos = cinematicPos5;
                }
                else if (cinematic6)
                {
                    currentPos = cinematicPos6;
                }
                else
                {
                    currentPos = terminalPos;
                }
            }
            else
            {
                currentPos = quad0Pos;
            }
        }

        if (quad1)
        {
            currentPos = quad1Pos;
        }

        if (quad2)
        {
            if (fuse)
            {
                currentPos = fusePos;
            }
            else
            {
                currentPos = quad2Pos;
            }
        }

        if (quad3)
        {
            currentPos = quad3Pos;
        }
    }

    private void LateUpdate()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, currentPos.position, ref velocity, Time.deltaTime * speed, maxSpeed);
        transform.position = Vector3.Lerp(transform.position, currentPos.position, Time.deltaTime * speed);

        Vector3 currentAngle = new Vector3(Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentPos.transform.rotation.eulerAngles.x, Time.deltaTime * speed),
                                           Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentPos.transform.rotation.eulerAngles.y, Time.deltaTime * speed),
                                           Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentPos.transform.rotation.eulerAngles.z, Time.deltaTime * speed));
        transform.eulerAngles = currentAngle;
    }

    public void Quad0Trigger(bool state)
    {
        quad0 = state;
    }
    public void Quad1Trigger(bool state)
    {
        quad1 = state;
    }
    public void Quad2Trigger(bool state)
    {
        quad2 = state;
    }
    public void Quad3Trigger(bool state)
    {
        quad3 = state;
    }
    public void FuseTrigger(bool state)
    {
        fuse = state;
    }
    public void TerminalTrigger(bool state)
    {
        terminal = state;
    }
    public void CinematicOne(bool state)
    {
        cinematic1 = state;
    }
    public void CinematicTwo(bool state)
    {
        cinematic2 = state;
    }
    public void CinematicThree(bool state)
    {
        cinematic3 = state;
    }
    public void CinematicFour(bool state)
    {
        cinematic4 = state;
    }
    public void CinematicFive(bool state)
    {
        cinematic5 = state;
    }
    public void CinematicSix(bool state)
    {
        cinematic6 = state;
    }
    public void SetCamSpeed(float value)
    {
        speed = value;
    }

}
