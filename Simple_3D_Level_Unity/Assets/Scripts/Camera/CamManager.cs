using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public Camera mainRoomCam;
    public Camera corridorCam;
    public Camera endRoomCam;
    public Camera testCam;

    public GameObject testRoom;

    private bool mainRoom = true;
    private bool corridor = false;
    private bool endRoom = false;

    // Start is called before the first frame update
    private void Awake()
    {
        DisableCameras();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!testRoom.activeSelf)
        {
            mainRoomCam.enabled = mainRoom;

            corridorCam.enabled = corridor;

            endRoomCam.enabled = endRoom;
        }
        else
        {
            testCam.enabled = true;
        }
        
    }

    public void MainRoomActive(bool state)
    {
        mainRoom = state;
    }
    public void CorridorActive(bool state)
    {
        corridor = state;
    }
    public void EndRoomActive(bool state)
    {
        endRoom = state;
    }
    private void DisableCameras()
    {
        mainRoomCam.enabled = false;

        corridorCam.enabled = false;

        endRoomCam.enabled = false;

        testCam.enabled = false;
    }
}
