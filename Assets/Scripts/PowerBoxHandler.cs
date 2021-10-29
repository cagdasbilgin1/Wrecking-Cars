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
        lineRender.enabled = false;
        hinge.useMotor = true;
        trail.enabled = true;
        StartCoroutine(StopTwisterAfterSeconds(powerTime));
    }

    IEnumerator StopTwisterAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        hinge.useMotor = false;
        lineRender.enabled = true;
        trail.enabled = false;
    }
}
