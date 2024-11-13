using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoomCameraMovement : MonoBehaviour
{
    public float speed = 3f;

    public Transform[] cameraPositions;
    private Transform currentPos;

    private bool position1;
    private bool position2;
    private bool position3;
    private bool position4;
    private bool position5;

    private void Awake()
    {
        currentPos = cameraPositions[0];
    }

    private void Update()
    {
        if (position1)
        {
            currentPos = cameraPositions[0];
        }
        if (position2)
        {
            currentPos = cameraPositions[1];
        }
        if (position3)
        {
            currentPos = cameraPositions[2];
        }
        if (position4)
        {
            currentPos = cameraPositions[3];
        }
        if (position5)
        {
            currentPos = cameraPositions[4];
        }
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentPos.position, Time.deltaTime * speed);

        Vector3 currentAngle = new Vector3(Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentPos.transform.rotation.eulerAngles.x, Time.deltaTime * speed),
                                           Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentPos.transform.rotation.eulerAngles.y, Time.deltaTime * speed),
                                           Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentPos.transform.rotation.eulerAngles.z, Time.deltaTime * speed));
        transform.eulerAngles = currentAngle;
    }

    public void PositionOne(bool state)
    {
        position1 = state;
    }

    public void PositionTwo(bool state)
    {
        position2 = state;
    }

    public void PositionThree(bool state)
    {
        position3 = state;
    }

    public void PositionFour(bool state)
    {
        position4 = state;
    }

    public void PositionFive(bool state)
    {
        position5 = state;
    }
}
