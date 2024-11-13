using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public Collider player;
    public TrapManager trapManager;

    public float delayPlat1 = 5f;
    public float delayPlat2 = 1f;
    public float delayPlat3 = 3f;
    public float delayBall1 = 3f;
    public float delayBall2 = 3f;
    public float delayBoulder = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (player == other)
        {
            StartCoroutine(FallingPlatOne());
            StartCoroutine(FallingPlatTwo());
            StartCoroutine(FallingPlatThree());
            StartCoroutine(SpikedBallOne());
            StartCoroutine(SpikedBallTwo());
            StartCoroutine(Boulder());
        }
    }

    IEnumerator FallingPlatOne()
    {
        yield return new WaitForSecondsRealtime(delayPlat1);
        trapManager.StartPlat1(true);
    }
    IEnumerator FallingPlatTwo()
    {
        yield return new WaitForSecondsRealtime(delayPlat2);
        trapManager.StartPlat2(true);
    }
    IEnumerator FallingPlatThree()
    {
        yield return new WaitForSecondsRealtime(delayPlat3);
        trapManager.StartPlat3(true);
    }
    IEnumerator SpikedBallOne()
    {
        yield return new WaitForSecondsRealtime(delayBall1);
        trapManager.StartBall1(true);
    }
    IEnumerator SpikedBallTwo()
    {
        yield return new WaitForSecondsRealtime(delayBall2);
        trapManager.StartBall2(true);
    }
    IEnumerator Boulder()
    {
        yield return new WaitForSecondsRealtime(delayBoulder);
        trapManager.StartBoulder(true);
    }
}
