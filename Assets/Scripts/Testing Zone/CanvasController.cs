using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject shopCanvas;

    [SerializeField] GameObject[] items;
    [SerializeField] Transform positionOne;
    [SerializeField] Transform positionTwo;
    [SerializeField] Transform positionThree;

    public void DisableShop()
    {
        shopCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void InstantiateItems()
    {
        Instantiate(items[Random.Range(0, items.Length)], positionOne.transform);
        Instantiate(items[Random.Range(0, items.Length)], positionTwo.transform);
        Instantiate(items[Random.Range(0, items.Length)], positionThree.transform);
    }
}
