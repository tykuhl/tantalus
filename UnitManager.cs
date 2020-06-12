using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public Unit data;

    public bool TakeDamage(int dmg)
    {
        data.currentHP -= dmg;

        if (data.currentHP <= 0)
            return true;
        else
            return false;
    }

    public void HealDamage(int dmg)
    {
        // if healing is more than max hp, heal only partial amount
        if ((dmg + data.currentHP) > data.maxHP)
            data.currentHP = data.maxHP;
        else if (dmg + data.currentHP <= data.maxHP)
            data.currentHP += dmg;
    }
}
