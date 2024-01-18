using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private GameManager gameManager;
    private CanvasController canvasConroller;

    public BoxCollider boxCollider { get; private set; }

    private bool isActive = false;
    [SerializeField] private GameObject shopCanvas;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        canvasConroller = GameObject.Find("Global_Canvas").GetComponent<CanvasController>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerStay(Collider collison)
    {
        if(collison.tag == "Player" && Input.GetKeyDown(KeyCode.F))
            EnableShop();
    }

    private void EnableShop()
    {
        if (gameManager.countdown >= 0)
        {
            shopCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            canvasConroller.InstantiateItems();
        }
    }

}
