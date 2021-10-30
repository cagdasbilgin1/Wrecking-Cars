using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideKiller : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            GameManager.Instance.ReloadLevel();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("You Won");
            GameManager.Instance.ReloadLevel();
        }
        Destroy(other.gameObject);
    }
}
