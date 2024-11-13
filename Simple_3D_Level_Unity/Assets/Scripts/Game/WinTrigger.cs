using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public Collider player;
    public PlayerMovement playerScript;

    private void OnTriggerEnter(Collider other)
    {
        if(player == other)
        {
            playerScript.Win(true);
        }
    }
}
