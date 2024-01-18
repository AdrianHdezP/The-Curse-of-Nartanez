using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UI_Player : MonoBehaviour
{
    [Header("Stamina Info")]
    public float stamina;
    public float maxStamina;
    [Space]
    public Slider staminaSlider;
    public float decreaseValue;
    public float increaseValue;

    public TextMeshProUGUI coinValueTmp;
    public int coinValue = 0;

    private void Start()
    {
        stamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
    }
    private void Update()
    {
        staminaSlider.value = stamina;
        coinValueTmp.SetText(coinValue.ToString());
    }

    public void DecreaseStamina()
    {
        if (stamina <= 0)
            return;
        else if (stamina >= maxStamina + 1)
            return;
        else
            stamina -= decreaseValue * Time.deltaTime;
    }
    public void IncreaseStamina()
    {
        if (stamina >= maxStamina)
            return;
        else
            stamina += increaseValue * Time.deltaTime;
    }
}
