using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPEffect : MonoBehaviour
{
    public GameObject ball;
    public ParticleSystem effect;

    private void Awake()
    {
        effect.transform.position = ball.transform.position;
    }

    private void Update()
    {
        effect.transform.position = ball.transform.position;
    }
}
