using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateDisplay : MonoBehaviour
{
    public TMP_Text valueText, costText;

    public GameObject upgradeButton;

    public void UpdateDisplays(int cost, float oldValue, float newValue)
    {
        valueText.text = "Value: " + oldValue.ToString("F1") + "->" + newValue.ToString("F1");
        costText.text = "Cost: " + cost;

        if (cost <= CoinController.instance.currentCoin)
        {
            upgradeButton.SetActive(true);
        }
        else
        {
            upgradeButton.SetActive(false);
        }
    }

    public void ShowMaxLevel()
    {
        valueText.text = "Max Level";
        costText.text = "Max Level";
        upgradeButton.SetActive(false);
    }
}
