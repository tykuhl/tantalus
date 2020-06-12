using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Unit")]
public class Unit : ScriptableObject
{
    public string unitName;
    public GameObject model;
    public int level;
    public int damage;
    public int maxHP;
    public int currentHP;
    public int speed;
    public bool isEnemy;
}
