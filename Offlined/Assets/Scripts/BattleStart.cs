using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Maintains persistent PlayerParty object so player stats are kept
public class BattleStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;

        this.gameObject.SetActive(false);
    }

    //If the current scene is the Real World, destroy to avoid duplicates; else become active if in Battle
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "RealWorld")
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.SetActive(scene.name == "Battle");
        }
    }
}
