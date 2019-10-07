using UnityEngine;
using System.Collections;

//Enemy unit in-battle behaviour
public class EnemyUnitAction : MonoBehaviour
{
    [SerializeField]
    private GameObject attack;

    [SerializeField]
    private string targetsTag;

    //Upon Awake, acquire target
    void Awake()
    {
        this.attack = Instantiate(this.attack);

        this.attack.GetComponent<AttackUnit>().owner = this.gameObject;
    }

    //Seek a random target from the tagged targets e.g. Players seek out Enemy tags
    GameObject findRandomTarget()
    {
        GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag(targetsTag);

        if (possibleTargets.Length > 0)
        {
            int targetIndex = Random.Range(0, possibleTargets.Length);
            GameObject target = possibleTargets[targetIndex];

            return target;
        }

        return null;
    }

    public void act()
    {
        GameObject target = findRandomTarget();
        this.attack.GetComponent<AttackUnit>().hit(target);
    }
}