using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCamSelector : MonoBehaviour
{
    public Collider player;
    public CamManager camMan;
    //public FirstPersonCam fpCam;

    public bool mainRoom = false;
    public bool corridor = false;
    public bool endRoom = false;

    private void OnTriggerEnter(Collider other)
    {
        if (player == other)
        {
            if (mainRoom)
            {
                camMan.MainRoomActive(true);
                //fpCam.enabled = false;
            }

            if (corridor)
            {
                camMan.CorridorActive(true);
                //fpCam.enabled = true;
            }

            if (endRoom)
            {
                camMan.EndRoomActive(true);
                //fpCam.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (player == other)
        {
            if (mainRoom)
            {
                camMan.MainRoomActive(false);
            }

            if (corridor)
            {
                camMan.CorridorActive(false);
            }

            if (endRoom)
            {
                camMan.EndRoomActive(false);
            }
        }
    }
}
