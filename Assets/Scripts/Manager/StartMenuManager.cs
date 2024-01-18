using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{

    [Header("Canvas")]
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject optionsCanvas;
    [SerializeField] private GameObject graphicsCanvas;
    [SerializeField] private GameObject soundCanvas;
    [SerializeField] private GameObject gameplayCanvas;
    [SerializeField] private GameObject characterCanvas;
    [SerializeField] private GameObject gameModeCanvas;
    [SerializeField] private GameObject campaignMapCanvas;
    [SerializeField] private GameObject hordeMapCanvas;

    [Header("Characters")]
    [SerializeField] private bool player1;
    [SerializeField] private bool player2;
    [SerializeField] private bool player3;

    [Header("Sound Settings")]
    [SerializeField] private TextMeshProUGUI volumeTextValue;
    [SerializeField] private Slider volumeSlider;

    private void Update()
    {
        player1 = PlayerPrefs.GetInt("player1Select") == 1;
        player2 = PlayerPrefs.GetInt("player2Select") == 1;
        player3 = PlayerPrefs.GetInt("player3Select") == 1;
    }

    public void StartGame()
    {
        startCanvas.SetActive(false);
        characterCanvas.SetActive(true);
    }

    public void StartExitGame()
    {
        Application.Quit();
    }

    #region Options

    public void StartOptions()
    {
        startCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    public void Graphics()
    {
        optionsCanvas.SetActive(false);
        graphicsCanvas.SetActive(true);
    }

    public void Sound()
    {
        optionsCanvas.SetActive(false);
        soundCanvas.SetActive(true);
    }

    public void Gameplay()
    {
        optionsCanvas.SetActive(false);
        gameplayCanvas.SetActive(true);
    }

    public void ReturnToOptions()
    {
        graphicsCanvas.SetActive(false);
        soundCanvas.SetActive(false);
        gameplayCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    public void ReturnToStart()
    {
        optionsCanvas.SetActive(false);
        startCanvas.SetActive(true);
    }

    #endregion

    #region Sound Options

    public void SetVolume(float _volume)
    {

    }

    #endregion

    #region Choose Character

    public void Player1()
    {
        player1 = true;
        player2 = false;
        player3 = false;
        SavePrefs();
        characterCanvas.SetActive(false);
        gameModeCanvas.SetActive(true);
    }

    public void Player2()
    {
        player1 = false;
        player2 = true;
        player3 = false;
        SavePrefs();
        characterCanvas.SetActive(false);
        gameModeCanvas.SetActive(true);
    }

    public void Player3()
    {
        player1 = false;
        player2 = false;
        player3 = true;
        SavePrefs();
        characterCanvas.SetActive(false);
        gameModeCanvas.SetActive(true);
    }

    #endregion

    #region Game Modes

    public void Campaign()
    {
        gameModeCanvas.SetActive(false);
        campaignMapCanvas.SetActive(true);
    }

    public void Horde()
    {
        gameModeCanvas.SetActive(false);
        hordeMapCanvas.SetActive(true);
    }

    #endregion

    #region Load Scene

    public void LoadMap1Campaign()
    {
        SceneManager.LoadScene("Campaign_Level_Scene");
    }

    public void LoadMap1Horde()
    {
        SceneManager.LoadScene("Horde_Level_Scene");
    }

    #endregion

    public void SavePrefs()
    {
        PlayerPrefs.SetInt("player1Select", player1 ? 1 : 0);
        PlayerPrefs.SetInt("player2Select", player2 ? 1 : 0);
        PlayerPrefs.SetInt("player3Select", player3 ? 1 : 0);
    }
}
