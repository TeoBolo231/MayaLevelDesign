using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour
{
    public int jumpBool;
    public int sprintBool;
    public int speedFloat;
    public int deadBool;
    public int sparksBool;
    public int pickUpCol;
    public int pickUpTer;

    private void Awake()
    {
        jumpBool = Animator.StringToHash("jump");
        sprintBool = Animator.StringToHash("sprint");
        speedFloat = Animator.StringToHash("speed");
        deadBool = Animator.StringToHash("dead");
        sparksBool = Animator.StringToHash("sparks");
        pickUpCol = Animator.StringToHash("pickupColumn");
        pickUpTer = Animator.StringToHash("pickupTerminal");
    }
}
