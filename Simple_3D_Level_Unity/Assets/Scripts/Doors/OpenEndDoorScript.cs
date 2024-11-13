using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEndDoorScript : MonoBehaviour
{
    public GameObject player;
    public DoorManager doorManager;

    private bool trigger = false;
    private bool open = false;

    private void OnTriggerEnter(Collider other)
    {
        if (player.GetComponent<Collider>() == other)
        {
            trigger = !trigger;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (player.GetComponent<Collider>() == other)
        {
            trigger = !trigger;
        }
    }

    private void Update()
    {
        if (trigger && Input.GetKeyDown(KeyCode.E))
        {
            open = !open;
            doorManager.OpenEndDoor(open);
        }
    }
}
