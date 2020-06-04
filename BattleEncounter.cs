using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleEnvironmentEnum { WOODS, SNOW, MOUNTAIN, HOUSE, CASTLE }

public class BattleEncounter : MonoBehaviour
{
    public BattleEnvironmentEnum environment; 
    
    IList<Unit> playerUnits = new List<Unit>();
    IList<Unit> enemyUnits = new List<Unit>();

}
