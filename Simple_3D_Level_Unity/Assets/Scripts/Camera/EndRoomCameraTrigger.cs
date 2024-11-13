using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoomCameraTrigger : MonoBehaviour
{
    public GameObject player;
    public EndRoomCameraMovement camScript;

    public bool position1 = false;
    public bool position2 = false;
    public bool position3 = false;
    public bool position4 = false;
    public bool position5 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (player.GetComponent<Collider>() == other)
        {
            if (position1)
            {
                camScript.PositionOne(true);
            }

            if (position2)
            {
                camScript.PositionTwo(true);
            }

            if (position3)
            {
                camScript.PositionThree(true);
            }

            if (position4)
            {
                camScript.PositionFour(true);
            }
            if (position5)
            {
                camScript.PositionFive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (player.GetComponent<Collider>() == other)
        {
            if (position1)
            {
                camScript.PositionOne(false);
            }

            if (position2)
            {
                camScript.PositionTwo(false);
            }

            if (position3)
            {
                camScript.PositionThree(false);
            }

            if (position4)
            {
                camScript.PositionFour(false);
            }

            if (position5)
            {
                camScript.PositionFive(false);
            }
        }
    }
}

