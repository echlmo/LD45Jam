using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

//Script to trigger a battle upon enemy encounter; transports player to battle scene upon contact with EnemySpawner prefab
public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyEncounterPrefab;

    private bool spawning = false;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Battle")
        {
            if (this.spawning)
            {
                Instantiate(enemyEncounterPrefab);
            }
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //If collided with player, go to Battle scene
        if (other.gameObject.tag == "Player")
        {
            this.spawning = true;
            SceneManager.LoadScene("Battle");
        }
    }
}
