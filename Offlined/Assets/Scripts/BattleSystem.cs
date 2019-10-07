using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// TODO: Battle system - decide turn based or 'timer' based system
public class BattleSystem : MonoBehaviour
{
    private List<GameUnitStats> unitsStats;

    [SerializeField]
    private GameObject actionsMenu, enemyUnitsMenu;

    // Use this for initialization
    void Start()
    {
        unitsStats = new List<GameUnitStats>();
        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        foreach (GameObject playerUnit in playerUnits)
        {
            GameUnitStats currentUnitStats = playerUnit.GetComponent<GameUnitStats>();
            //currentUnitStats.calculateNextActTurn(0);
            unitsStats.Add(currentUnitStats);
        }

        GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        foreach (GameObject enemyUnit in enemyUnits)
        {
            GameUnitStats currentUnitStats = enemyUnit.GetComponent<GameUnitStats>();
            //currentUnitStats.calculateNextActTurn(0);
            unitsStats.Add(currentUnitStats);
        }
        unitsStats.Sort();

        //Set up next turn

    }

}
