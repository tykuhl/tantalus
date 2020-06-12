using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI Unit1_name;
    public TextMeshProUGUI Unit1_currentHP;
    public TextMeshProUGUI Unit2_name;
    public TextMeshProUGUI Unit2_currentHP;
    public TextMeshProUGUI Unit3_name;
    public TextMeshProUGUI Unit3_currentHP;
    public TextMeshProUGUI Unit4_name;
    public TextMeshProUGUI Unit4_currentHP;

    public Button healButton;
    public Button attackButton;
    public TextMeshProUGUI attackButtonText;
    public TextMeshProUGUI healButtonText;

    public void SetHUD(UnitManager unit)
    {
        Debug.Log(unit.data);
        if (!(unit.data.isEnemy))
        {
            if (Unit1_name.text == "Name")
            {
                Unit1_name.text = unit.data.unitName;
                Unit1_currentHP.SetText(unit.data.currentHP.ToString());
            }
            else if (Unit2_name.text == "Name")
            {
                Unit2_name.text = unit.data.unitName;
                Unit2_currentHP.SetText(unit.data.currentHP.ToString());
            }
            else if (Unit3_name.text == "Name")
            {
                Unit3_name.text = unit.data.unitName;
                Unit3_currentHP.SetText(unit.data.currentHP.ToString());
            }
            else if (Unit4_name.text == "Name")
            {
                Unit4_name.text = unit.data.unitName;
                Unit4_currentHP.SetText(unit.data.currentHP.ToString());
            }
        } else if (unit.data.isEnemy)
        {
            if (Unit1_name.text == "enemyName")
            {
                Unit1_name.text = unit.data.unitName;
                Unit1_currentHP.SetText(unit.data.currentHP.ToString());
            }
            else if (Unit2_name.text == "enemyName")
            {
                Unit2_name.text = unit.data.unitName;
                Unit2_currentHP.SetText(unit.data.currentHP.ToString());
            }
            else if (Unit3_name.text == "enemyName")
            {
                Unit3_name.text = unit.data.unitName;
                Unit3_currentHP.SetText(unit.data.currentHP.ToString());
            }
            else if (Unit4_name.text == "enemyName")
            {
                Unit4_name.text = unit.data.unitName;
                Unit4_currentHP.SetText(unit.data.currentHP.ToString());
            }
        }
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
