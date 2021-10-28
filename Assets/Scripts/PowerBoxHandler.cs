using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoxHandler : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] float powerTime;
    HingeJoint hinge;
    void Start()
    {
        hinge = ball.GetComponent<HingeJoint>();
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
        hinge.useMotor = true;
        StartCoroutine(StopTwisterAfterSeconds(powerTime));
    }

    IEnumerator StopTwisterAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        hinge.useMotor = false;
    }
}