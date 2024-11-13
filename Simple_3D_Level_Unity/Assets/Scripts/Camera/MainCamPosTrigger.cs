using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamPosTrigger : MonoBehaviour
{
    public Collider playerColl;
    public MainRoomCameraMovement camScript;
    public LookAtCam lookAtCam;

    public bool quad0;
    public bool quad1;
    public bool quad2;
    public bool quad3;
    public bool fuse;
    public bool terminal;

    private void OnTriggerEnter(Collider other)
    {
        if(playerColl == other)
        {
            if (quad0)
            {
                camScript.Quad0Trigger(true);
            }

            if (quad1)
            {
                camScript.Quad1Trigger(true);
            }

            if (quad2)
            {
                camScript.Quad2Trigger(true);
            }

            if (quad3)
            {
                camScript.Quad3Trigger(true);
            }

            if (fuse)
            {
                camScript.FuseTrigger(true);
                lookAtCam.CamActive(false);
            }

            if (terminal)
            {
                camScript.TerminalTrigger(true);
                lookAtCam.CamActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (playerColl == other)
        {
            if (quad0)
            {
                camScript.Quad0Trigger(false);
            }

            if (quad1)
            {
                camScript.Quad1Trigger(false);
            }

            if (quad2)
            {
                camScript.Quad2Trigger(false);
            }

            if (quad3)
            {
                camScript.Quad3Trigger(false);
            }

            if (fuse)
            {
                camScript.FuseTrigger(false);
                lookAtCam.CamActive(true);
            }

            if (terminal)
            {
                camScript.TerminalTrigger(false);
                lookAtCam.CamActive(true);
            }
        }
    }
}
