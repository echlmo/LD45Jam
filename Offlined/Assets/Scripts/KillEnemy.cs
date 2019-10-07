using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour { 

    public GameObject enemy;

    // Destroy enemy
    private void OnDestroy()
    {
        Destroy(this.enemy);
    }
}
