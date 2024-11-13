using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseManager : MonoBehaviour
{
    public GameObject fuseColumn;
    public GameObject fuseTerminal;
    public GameObject fuseWaist;

    public DoorManager doorManager;
    public PlayerMovement player;

    private bool origin = true;
    private bool held = false;
    private bool placed = false;
    private bool tranCol = false;
    private bool tranTer = false;
    private bool open = false;

    private MeshRenderer meshFuseCol;
    private MeshRenderer meshFuseWaist;
    private MeshRenderer meshFuseTer;
    private bool alreadyStartedCol = false;
    private bool alreadyStartedTer = false;

    private void Awake()
    {
        meshFuseCol = fuseColumn.GetComponent<MeshRenderer>();
        meshFuseWaist = fuseWaist.GetComponent<MeshRenderer>();
        meshFuseTer = fuseTerminal.GetComponent<MeshRenderer>();

        meshFuseCol.enabled = origin;
        meshFuseWaist.enabled = held;
        meshFuseTer.enabled = placed;
    }

    private void Update()
    {
        if (origin && tranCol && Input.GetKeyDown(KeyCode.E) && !alreadyStartedCol)
        {

            alreadyStartedCol = true;
            StartCoroutine(player.PickUpAnimCol());
            StartCoroutine(PickUpCol());
     
        }

        else if (!origin && held && tranCol && Input.GetKeyDown(KeyCode.E) && !alreadyStartedCol)
        {
            alreadyStartedCol = true;
            StartCoroutine(player.PickUpAnimCol());
            StartCoroutine(PutDownCol());
            
        }

        else if (held && tranTer && Input.GetKeyDown(KeyCode.E) && !alreadyStartedTer)
        {
            alreadyStartedTer = true;
            StartCoroutine(player.PickUpAnimTer());
            StartCoroutine(PutDownTer());
        }

        else if (!held && placed && tranTer && Input.GetKeyDown(KeyCode.E) && !alreadyStartedTer)
        {
            alreadyStartedTer = true;
            StartCoroutine(player.PickUpAnimTer());
            StartCoroutine(PickUpTer());
        }

        if (open)
        {
            doorManager.OpenMainDoor(open);
        }

        if (!open)
        {
            doorManager.OpenMainDoor(open);
        }

        meshFuseCol.enabled = origin;
        meshFuseWaist.enabled = held;
        meshFuseTer.enabled = placed;
    }

    public void TransitionColumn(bool tran) 
    {
        tranCol = tran;
    }

    public void TransitionTerminal(bool tran)
    {
        tranTer = tran;
    }
    IEnumerator PickUpCol()
    {
        yield return new WaitForSecondsRealtime(1);
        origin = !origin;
        yield return new WaitForSecondsRealtime(1.5f);
        held = !held;
        yield return new WaitForSecondsRealtime(1f);
        alreadyStartedCol = false;
    }
    IEnumerator PutDownCol()
    {
        held = !held;       
        yield return new WaitForSecondsRealtime(1);
        origin = !origin;
        yield return new WaitForSecondsRealtime(2);
        alreadyStartedCol = false;
    }
    IEnumerator PickUpTer()
    {
        yield return new WaitForSecondsRealtime(1);
        placed = !placed;
        yield return new WaitForSecondsRealtime(1);
        held = !held;
        yield return new WaitForSecondsRealtime(0.5f);
        open = !open;
        alreadyStartedTer = false;
    }
    IEnumerator PutDownTer()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        held = !held;
        yield return new WaitForSecondsRealtime(1);
        placed = !placed;
        yield return new WaitForSecondsRealtime(1f);
        open = !open;
        alreadyStartedTer = false;
    }
}
