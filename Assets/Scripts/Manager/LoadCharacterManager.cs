using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacterManager : MonoBehaviour
{
    [Header("Characters")]
    [SerializeField] private GameObject player1Model;
    [SerializeField] private GameObject player2Model;
    [SerializeField] private GameObject player3Model;
    [SerializeField] private bool player1;
    [SerializeField] private bool player2;
    [SerializeField] private bool player3;

    private void Update()
    {
        player1 = PlayerPrefs.GetInt("player1Select") == 1;
        player2 = PlayerPrefs.GetInt("player2Select") == 1;
        player3 = PlayerPrefs.GetInt("player3Select") == 1;

        if (player1 == true)
        {
            player1Model.SetActive(true);
            Destroy(player2Model);
            Destroy(player3Model);
        }

        if (player2 == true)
        {
            player2Model.SetActive(true);
            Destroy(player1Model);
            Destroy(player3Model);
        }

        if (player3 == true)
        {
            player3Model.SetActive(true);
            Destroy(player1Model);
            Destroy(player2Model);
        }
    }
}
