using UnityEngine;
using System.Collections;

//VR World character stats - not exhaustive or imperative, just some ideas of stats to go off
public class GameUnitStats : MonoBehaviour
{

    public float health;
    public float mana;
    public float attack;
    public float defence;
    public float speed;

    private bool dead = false;

    // Taking damage
    public void receiveDamage(float damage)
    {
        this.health -= damage;
        if (this.health <= 0)
        {
            this.dead = true;
            this.gameObject.tag = "DeadUnit";
            Destroy(this.gameObject);
        }
    }

        // Is unit dead?
        public bool isDead()
    {
        return this.dead;
    }
}
