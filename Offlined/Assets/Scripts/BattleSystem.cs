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
            //TODO: Something to calculate next turn and update stats
            unitsStats.Add(currentUnitStats);
        }

        GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        foreach (GameObject enemyUnit in enemyUnits)
        {
            GameUnitStats currentUnitStats = enemyUnit.GetComponent<GameUnitStats>();
            //TODO: Something to calculate next turn and update stats
            unitsStats.Add(currentUnitStats);
        }
        unitsStats.Sort();

        //Set up for next turn

    }

}
