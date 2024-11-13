using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    public GameObject player;

    private bool active = true;

    private void LateUpdate()
    {
        if (active)
        {
            transform.LookAt(player.transform);
        }
    }

    public void CamActive(bool state)
    {
        active = state;
    }
}
