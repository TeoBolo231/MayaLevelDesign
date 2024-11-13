using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBall : MonoBehaviour
{
    public Collider playerColl;
    public PlayerMovement playerController;


    private void OnCollisionEnter(Collision collision)
    {
        if (playerColl)
        {
            playerController.Dead(true);
        }
    }
    
}
