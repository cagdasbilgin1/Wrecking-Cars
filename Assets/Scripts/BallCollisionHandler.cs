using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    [SerializeField] int pushForce;
    [SerializeField] int liftForce;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Ground")
        {
            collision.rigidbody.AddExplosionForce(pushForce, transform.position, 5);
            collision.rigidbody.AddForce(Vector3.up * liftForce);
        }       
    }
}
