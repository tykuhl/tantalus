using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    IList<Unit> mylist = new List<Unit>();

    public void setupTurnSystem(IList<Unit> u)
    {
        foreach (var x in u)
        {
            mylist.Add(x);
        }

        showList(mylist);
    }

    public void showList(IList<Unit> l)
    {
        foreach (var x in l)
        {
            Debug.Log(x.unitName + ", Speed: " + x.speed + ", Current HP: " + x.currentHP);
        }
    }

}
