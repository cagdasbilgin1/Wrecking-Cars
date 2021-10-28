using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideKiller : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("game over");
            Destroy(other.gameObject);
        }
    }
}
