using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    IList<UnitManager> mylist = new List<UnitManager>();

    public void setupTurnSystem(IList<UnitManager> u)
    {
        foreach (var x in u)
        {
            mylist.Add(x);
        }

        showList(mylist);
    }

    public void showList(IList<UnitManager> l)
    {
        foreach (var x in l)
        {
            Debug.Log(x.data.unitName + ", Speed: " + x.data.speed + ", Current HP: " + x.data.currentHP);
        }
    }

}
