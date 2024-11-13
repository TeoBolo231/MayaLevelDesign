using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuseTrigger : MonoBehaviour
{
    public GameObject player;
    public FuseManager fMan;

    public bool columnTrigger;
    public bool terminalTrigger;
    private bool transition = false;

    private void OnTriggerEnter(Collider other)
    {
        if (player.GetComponent<Collider>() == other)
        {
            transition = !transition;

            if (columnTrigger)
            {
                fMan.TransitionColumn(transition);
            }
            else if (terminalTrigger)
            {
                fMan.TransitionTerminal(transition);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (player.GetComponent<Collider>() == other)
        {
            transition = !transition;

            if (columnTrigger)
            {
                fMan.TransitionColumn(transition);
            }

            else if (terminalTrigger)
            {
                fMan.TransitionTerminal(transition);
            }
        }
    }
}
