using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public bool HardDrive;
    public int level;
    public int xp;
    public bool Healer;
    public bool RAM;
    public bool DPS;
    public bool Graphics;

    private static State state;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        if(state == null)
        {
            state = this;
        }
        if(state != this)
        {
            Destroy(this);
        }
        FindObjectOfType<PlayerControllerRL>().state = this;
        HardDrive = false;
        level = 0;
        xp = 0;
        Healer = false;
        RAM = false;
        DPS = false;
        Graphics = false;
    }

    
}
