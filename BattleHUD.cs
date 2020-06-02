using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI Unit1_name;
    public TextMeshProUGUI Unit1_currentHP;

    public Button healButton;
    public Button attackButton;
    public TextMeshProUGUI attackButtonText;
    public TextMeshProUGUI healButtonText;

    public void SetHUD(Unit unit)
    {
        Unit1_name.text = unit.unitName;
        Unit1_currentHP.SetText(unit.currentHP.ToString());
    }

    
    public void SetHP(int hp)
    {
        Unit1_currentHP.SetText(hp.ToString());
    }
    
    public void EnableActions(BattleHUD hud)
    {
        hud.attackButton.GetComponent<Button>().enabled = true;
        hud.attackButton.GetComponent<Image>().enabled = true;
        hud.attackButtonText.GetComponent<TextMeshProUGUI>().enabled = true;
        hud.healButton.GetComponent<Button>().enabled = true;
        hud.healButton.GetComponent<Image>().enabled = true;
        hud.healButtonText.GetComponent<TextMeshProUGUI>().enabled = true;
    }

    public void DisableActions(BattleHUD hud)
    {
        hud.attackButton.GetComponent<Button>().enabled = false;
        hud.attackButton.GetComponent<Image>().enabled = false;
        hud.attackButtonText.GetComponent<TextMeshProUGUI>().enabled = false;
        hud.healButton.GetComponent<Button>().enabled = false;
        hud.healButton.GetComponent<Image>().enabled = false;
        hud.healButtonText.GetComponent<TextMeshProUGUI>().enabled = false;

    }
}
