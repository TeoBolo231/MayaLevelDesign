using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorManager : MonoBehaviour
{
    public GameObject mainDoor;
    public GameObject endDoor;
    public PlayerMovement player; 
    public MainRoomCameraMovement mainRoomCam;
    public ParticleSystem sparks1;
    public ParticleSystem sparks2;
    public Text inputText;
    public Image inputBG;
    

    public bool openMain = false;
    public bool stop = false;

    private Animator mainDoorAnim;
    private Animator endDoorAnim;
    
    private bool openEnd = false;
    private float sparksDelayTime = 3f;
    private float openDoorDelayTime = 19f;
    private float ballDelay = 2f;
    private float doorDelay = 2.5f;
    private float boulderDelay = 3;
    private float overviewDelay = 4f;
    private bool alreadyOpen = false;
    

    private void Awake()
    {
        mainDoorAnim = mainDoor.GetComponent<Animator>();
        endDoorAnim = endDoor.GetComponent<Animator>();

        mainDoorAnim.SetBool("openMainDoor", openMain);
        endDoorAnim.SetBool("openEndDoor", openEnd);

        sparks1.Stop();
        sparks2.Stop();
    }
    
    private void FixedUpdate()
    {
        if (openMain && !alreadyOpen)
        {
            StartCoroutine(Cinematic());
            alreadyOpen = true;
        }

        if (openEnd)
        {
            endDoorAnim.SetBool("openEndDoor", true);
        }
    }

    IEnumerator Cinematic()
    {
        player.Cinematic(true);
        player.DisableAnimations();
        inputBG.enabled = false;
        inputText.enabled = false;
        mainRoomCam.CinematicOne(true);
        sparks1.Play();
        sparks2.Play();
        player.SparksAnim(true);
        yield return new WaitForSecondsRealtime(sparksDelayTime);
        mainDoorAnim.SetBool("openMainDoor", true);
        mainRoomCam.SetCamSpeed(1);
        mainRoomCam.CinematicOne(false);
        mainRoomCam.CinematicTwo(true);
        yield return new WaitForSecondsRealtime(openDoorDelayTime);
        mainRoomCam.CinematicTwo(false);
        mainRoomCam.CinematicThree(true);
        yield return new WaitForSecondsRealtime(ballDelay);
        mainRoomCam.CinematicThree(false);
        mainRoomCam.CinematicFour(true);
        yield return new WaitForSecondsRealtime(ballDelay);
        mainRoomCam.CinematicFour(false);
        mainRoomCam.CinematicFive(true);
        yield return new WaitForSecondsRealtime(doorDelay);
        mainRoomCam.CinematicFive(false);
        mainRoomCam.CinematicSix(true);
        yield return new WaitForSecondsRealtime(boulderDelay);
        mainRoomCam.CinematicSix(false);
        mainRoomCam.CinematicTwo(true);
        yield return new WaitForSecondsRealtime(overviewDelay);
        mainRoomCam.CinematicTwo(false);
        mainRoomCam.SetCamSpeed(3);
        player.SparksAnim(false);
        player.Cinematic(false);
        mainRoomCam.CinematicTwo(false);
        inputBG.enabled = true;
        inputText.enabled = true;
    }
    public void OpenMainDoor(bool open)
    {
        openMain = open;
    }
    public void OpenEndDoor(bool open)
    {
        openEnd = open;
    }
}
