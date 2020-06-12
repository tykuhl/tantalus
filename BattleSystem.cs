using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerBattle : MonoBehaviour
{
    public Unit playerUnit1;
    public Unit playerUnit2;
    public Unit playerUnit3;
    public Unit playerUnit4;

    IList<Unit> playerUnits = new List<Unit>();
    IList<Unit> enemyUnits = new List<Unit>();

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerBattle collider entered");

        if (playerUnit1 != null && !(playerUnit1.isEnemy))
        {
            playerUnits.Add(playerUnit1);
        }
        if (playerUnit2 != null && !(playerUnit2.isEnemy))
        {
            playerUnits.Add(playerUnit2);
        }
        if (playerUnit3 != null && !(playerUnit3.isEnemy))
        {
            playerUnits.Add(playerUnit3);
        }
        if (playerUnit4 != null && !(playerUnit4.isEnemy))
        {
            playerUnits.Add(playerUnit4);
        }
        Debug.Log(playerUnits[2].unitName + "'s Speed is " + playerUnits[0].speed);
        //Debug.Log(playerUnits[2].data.unitName + "'s Speed is " + playerUnits[2].data.speed);

        /**

        // Scene Transition
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            SceneManager.LoadScene("battleScene");
        }

        **/

    }
}
