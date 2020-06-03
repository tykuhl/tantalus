using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public int currentHP;
    public int speed;
    public bool isEnemy;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public void HealDamage(int dmg)
    {
        // if healing is more than max hp, heal only partial amount
        if ((dmg + currentHP) > maxHP)
            currentHP = maxHP;
        else if (dmg + currentHP <= maxHP)
            currentHP += dmg;
    }
}
