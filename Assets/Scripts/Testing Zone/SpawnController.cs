using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && name == "Zone 1")
        {
            gameManager.spawnZoneBool1 = true;
        }

        if (other.tag == "Player" && name == "Zone 2")
        {
            gameManager.spawnZoneBool2 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && name == "Zone 1")
        {
            gameManager.spawnZoneBool1 = false;
        }

        if (other.tag == "Player" && name == "Zone 2")
        {
            gameManager.spawnZoneBool2 = false;
        }
    }
}
