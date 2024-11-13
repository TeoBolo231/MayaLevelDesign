using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorDeath : MonoBehaviour
{
    public PlayerMovement player;
    private bool tran = false;

    private void OnTriggerEnter(Collider other)
    {
        if (player.GetComponent<Collider>() == other)
        {
            tran = !tran;
            player.Dead(tran);
        }
    }
}
