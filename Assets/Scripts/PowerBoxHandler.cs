using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoxHandler : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] float powerTime;
    [SerializeField] LineRenderer lineRender;
    HingeJoint hinge;
    TrailRenderer trail;
    void Start()
    {
        hinge = ball.GetComponent<HingeJoint>();
        trail = ball.GetComponent<TrailRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TwisterBox"))
        {
            SpinBallAround();
            Destroy(other.gameObject);
        }
    }

    private void SpinBallAround()
    {
        if (lineRender)
        {
            lineRender.enabled = false;
        }
        if (hinge)
        {
            hinge.useMotor = true;
        }
        if (trail)
        {
            trail.enabled = true;
        }
        StartCoroutine(StopTwisterAfterSeconds(powerTime));
    }

    IEnumerator StopTwisterAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        if (lineRender)
        {
            lineRender.enabled = true;
        }
        if (hinge)
        {
            hinge.useMotor = false;
        }
        if (trail)
        {
            trail.enabled = false;
        }
    }
}
