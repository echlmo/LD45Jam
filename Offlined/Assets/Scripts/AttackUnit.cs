using UnityEngine;
using System.Collections;

//Attacking units in battle (usable by both enemy and player)
public class AttackUnit : MonoBehaviour
{
    public GameObject owner;

    [SerializeField]
    private string attackAnimation;

    [SerializeField]
    private float manaCost;

    [SerializeField]
    private float attackValue;

    [SerializeField]
    private float defenceMultiplier;

    [SerializeField]
    private float minAttackMultiplier;

    [SerializeField]
    private float maxAttackMultiplier;

    [SerializeField]
    private float minDefenseMultiplier;

    [SerializeField]
    private float maxDefenseMultiplier;

    //Calculating and implementing attacking a target
    public void hit(GameObject target)
    {
        GameUnitStats ownerStats = this.owner.GetComponent<GameUnitStats>();
        GameUnitStats targetStats = target.GetComponent<GameUnitStats>();

        if (ownerStats.mana >= this.manaCost)
        {
            float attackMultiplier = (Random.value * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
            float damage = attackMultiplier * ownerStats.attack;

            float defenseMultiplier = (Random.value * (this.maxDefenseMultiplier - this.minDefenseMultiplier)) + this.minDefenseMultiplier;
            damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defence));

            //
            //targetStats.takeDamage(damage);

            ownerStats.mana -= this.manaCost;
        }
    }
}
