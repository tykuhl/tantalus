using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    //public GameObject player1Prefab;
    //public GameObject player2Prefab;
    //public GameObject player3Prefab;
    //public GameObject enemy1Prefab;

    public Transform player1Spawn;
    public Transform player2Spawn;
    public Transform player3Spawn;
    public Transform player4Spawn;
    public Transform enemy1Spawn;
    public Transform enemy2Spawn;
    public Transform enemy3Spawn;
    public Transform enemy4Spawn;

    public Unit player1SO;

    public UnitManager player1Unit;
    public UnitManager player2Unit;
    public UnitManager player3Unit;
    public UnitManager player4Unit;
    public IList<Unit> playerUnitList;
    public UnitManager enemy1Unit;
    public UnitManager enemy2Unit;
    public UnitManager enemy3Unit;
    public UnitManager enemy4Unit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
       
        // Instantiating the prefab and locataion for player character 1
        Vector3 player1pos = player1Spawn.transform.position;
        Quaternion player1rot = player1Spawn.transform.rotation;
        GameObject player1GO = Instantiate(Resources.Load("cloud_prefab") as GameObject);
        player1GO.transform.position = player1pos;
        player1GO.transform.rotation = player1rot;
        player1Unit = player1GO.GetComponent<UnitManager>();

        // Instantiating the prefab and locataion for player character 2
        Vector3 player2pos = player2Spawn.transform.position;
        Quaternion player2rot = player2Spawn.transform.rotation;
        GameObject player2GO = Instantiate(Resources.Load("tifa_prefab") as GameObject);
        player2GO.transform.position = player2pos;
        player2GO.transform.rotation = player2rot;
        player2Unit = player2GO.GetComponent<UnitManager>();

        // Instantiating the prefab and locataion for enemy character 1
        Vector3 enemy1pos = enemy1Spawn.transform.position;
        Quaternion enemy1rot = enemy1Spawn.transform.rotation;
        GameObject enemy1GO = Instantiate(Resources.Load("sephiroth_prefab") as GameObject);
        enemy1GO.transform.position = enemy1pos;
        enemy1GO.transform.rotation = enemy1rot;
        enemy1Unit = enemy1GO.GetComponent<UnitManager>();

        







        /**
        Vector3 player1pos = player1Spawn.transform.position;
        Quaternion player1rot = player1Spawn.transform.rotation;
        GameObject player1GO = new GameObject();
        player1GO.AddComponent<UnitManager>();
        player1GO.GetComponent<UnitManager>().data = Resources.Load<Unit>("cloud");
        //player1GO = Instantiate(player1GO.GetComponent<UnitManager>().data.model);
        //player1GO.AddComponent<Rigidbody>();
        //player1GO.AddComponent<BoxCollider>();
        //player1GO.AddComponent<MeshRenderer>();
        //player1GO.transform.position = player1pos;
        //player1GO.transform.rotation = player1rot;
        **/

        //Debug.Log("BattleSystem: The player1Unit is " + player1Unit.data.unitName);










        /**
        Ideally this part will get Unit list from BattleEncounter, separated into enemy and player units.
        Then do a foreach loop for each Unit in the List to be sent to SetHUD method of BattleHUD
        **/
        var unitsFound = FindObjectsOfType<UnitManager>();
        Debug.Log("Objects of UnitManager type found: " + unitsFound);
        foreach (var x in unitsFound)
        {
            Debug.Log("The unit found is: " + x);
            playerHUD.SetHUD(x);
            enemyHUD.SetHUD(x);
        }

        //playerHUD.SetHUD(player1Unit);
        //enemyHUD.SetHUD(enemyUnit);

    


        //set up Turn system
        Debug.Log(unitsFound.Length +" units found in the battle:");

        IList<UnitManager> units = new List<UnitManager>();


        foreach (var x in unitsFound)
        {
            units.Add(x);
        }

        for (int i = 0; i < units.Count; i++)
        {
            Debug.Log(units[i].data.unitName + ", Speed: " + units[i].data.speed);
        }





        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        //MakeSelection();
        
        bool isDead = enemy1Unit.TakeDamage(player1Unit.data.damage);

        enemyHUD.SetHP(enemy1Unit.data.currentHP);
        Debug.Log("Attack successful against " + enemy1Unit);

        // Hide the player Actions options after selection is made
        playerHUD.DisableActions(playerHUD);

        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            EnemyTurn();
        }
    }

    IEnumerator PlayerHeal()
    {
        player1Unit.HealDamage(player1Unit.data.damage);

        playerHUD.SetHP(player1Unit.data.currentHP);
        Debug.Log("Heal successful");

        // Hide the player Actions options after selection is made
        playerHUD.DisableActions(playerHUD);

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        EnemyTurn();
    }

    IEnumerator EnemyAttack()
    {
        bool isDead = player1Unit.TakeDamage(enemy1Unit.data.damage);

        playerHUD.SetHP(player1Unit.data.currentHP);
        Debug.Log("Attack successful against " + player1Unit.data.unitName + "with " + player1Unit.data.currentHP + " HP");

        // Hide the enemy's Actions options after selection is made
        enemyHUD.DisableActions(enemyHUD);

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    IEnumerator EnemyHeal()
    {
        enemy1Unit.HealDamage(enemy1Unit.data.damage);

        enemyHUD.SetHP(enemy1Unit.data.currentHP);
        Debug.Log("Heal successful");

        // Hide the enemy's Actions options after selection is made
        enemyHUD.DisableActions(enemyHUD);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void EnemyTurn()
    {
        // enemy logic
        Debug.Log("Enemy's turn");

        // enable the enemy Actions when their turn starts
        enemyHUD.EnableActions(enemyHUD);


        //yield return new WaitForSeconds(2f);
    }

    void PlayerTurn()
    {
        Debug.Log("Choose an action:");

        // enable the player's Actions when their turn starts
        playerHUD.EnableActions(playerHUD);
    }

    /**
    Unit MakeSelection()
    {
        // spawn indicator arrow thingy over the first enemy Unit.
        // set var selectedUnit to enemy1Unit
        // if input is W or Up Arrow, change selection.
        

        if (Input.GetButtonDown("Submit"))
        {
            // return Unit
        }
    }
    **/

    public void OnPlayerAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnPlayerHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

    // This is used for debugging until the enemy logic is created
    public void OnEnemyAttackButton()
    {
        if (state != BattleState.ENEMYTURN)
            return;

        StartCoroutine(EnemyAttack());
    }

    public void OnEnemyHealButton()
    {
        if (state != BattleState.ENEMYTURN)
            return;

        StartCoroutine(EnemyHeal());
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            Debug.Log("You won the battle!");
        }
        else if (state == BattleState.LOST)
        {
            Debug.Log("You were defeated!");
        }
    }
}
