﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerRL : MonoBehaviour
{
	public float speed = 1.0f;
	Rigidbody2D Rigidbody;
    public State state;
	public Animator Animator;
	public CameraScript CameraScript;
	public GameObject LeaveRoomCollider;
	public GameObject ToProtagRoomCollider;
    public GameObject GarbageCollider;
    public GameObject HardWareStoreCollider;
    public GameObject ReturnToStreetCollider;
    public GameObject ReturnLV50Collider;
    public GameObject LV50Collider;
    public GameObject GraphicsCollider;
    public GameObject RamCollider;
    public GameObject VRCollider;
    public GameObject HealerCollider;
    public GameObject DPSCollider;
    // Start is called before the first frame update
    void Start()
    {
		Rigidbody = GetComponent<Rigidbody2D>();
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
		//Movement
		Rigidbody.velocity = new Vector2(speed*Input.GetAxis("Horizontal"),0);
		if (Input.GetAxis("Horizontal")<0){
			transform.localScale = new Vector2(-1,1);
			Animator.SetBool("Moving",true);
		}
		if (Input.GetAxis("Horizontal")>0){
			transform.localScale = new Vector2(1,1);
			Animator.SetBool("Moving", true);
		}
		if (Input.GetAxis("Horizontal")==0){
			Animator.SetBool("Moving",false);
		}
        if (Input.GetButtonDown("Interact"))
        {

            if (LeaveRoomCollider.GetComponent<BoxCollider2D>().bounds.Contains(this.transform.position)) { 
                ToStreet();
            }
            
            else if (ToProtagRoomCollider.GetComponent<BoxCollider2D>().bounds.Contains(this.transform.position))
            {
                ToProtagRoom();
            }

            else if (ReturnLV50Collider.GetComponent<BoxCollider2D>().bounds.Contains(this.transform.position))
            {
                ParkReturn();
            }
            else if (ReturnToStreetCollider.GetComponent<BoxCollider2D>().bounds.Contains(this.transform.position))
            {
                BarReturn();
            }
            else if (LV50Collider.GetComponent<BoxCollider2D>().bounds.Contains(this.transform.position) && state.level >= 50) //also has a level check, need to display this
            {
                ToPark();
            }
            else if (HardWareStoreCollider.GetComponent<BoxCollider2D>().bounds.Contains(this.transform.position) && state.level >=5) //also has a level check, need to display this
            {
                ToBar();
            }
            //object pickup
            else if (GarbageCollider.GetComponent<BoxCollider2D>().bounds.Contains(this.transform.position))
            {
                HardDrive();
            }
            else if (GraphicsCollider.GetComponent<BoxCollider2D>().bounds.Contains(this.transform.position))
            {
                GraphicsCard();
            }
            else if (RamCollider.GetComponent<BoxCollider2D>().bounds.Contains(this.transform.position))
            {
                Ram();
            }
            //talk to npc or enter vr
            else if (VRCollider.GetComponent<BoxCollider2D>().bounds.Contains(this.transform.position))
            {
                VR();
            }
            else if (HealerCollider.GetComponent<BoxCollider2D>().bounds.Contains(this.transform.position))
            {
                Healer();
            }
            else if (DPSCollider.GetComponent<BoxCollider2D>().bounds.Contains(this.transform.position))
            {
                DPS();
            }
        }
	}
	
	//Changing positions inside Real world.
	void ToStreet(){
		CameraScript.ToStreet(this.transform);
        transform.position = ToProtagRoomCollider.transform.position;
	}
    void ParkReturn()
    {
        CameraScript.ToStreet(this.transform);
        transform.position = LV50Collider.transform.position;
    }
    void BarReturn()
    {
        CameraScript.ToStreet(this.transform);
        transform.position = HardWareStoreCollider.transform.position;
    }
	void ToProtagRoom(){
		CameraScript.ToProtagRoom();
        transform.position = LeaveRoomCollider.transform.position;
	}
	void ToPark()
    {
        CameraScript.ToPark();
        transform.position = ReturnLV50Collider.transform.position; 
    }
    void ToBar()
    {
        CameraScript.ToBar();
        transform.position = ReturnToStreetCollider.transform.position;
    }
    //Picking up hardware
    void HardDrive()
    {
        GarbageCollider.SetActive(false);
        state.HardDrive = true;
    }
    void GraphicsCard()
    {
        GraphicsCollider.SetActive(false);
        state.Graphics = true;
    }
    void Ram()
    {
        RamCollider.SetActive(false);
        state.RAM = true;
    }
    void VR()
    {
        if (state.Graphics == true && state.DPS == true)
        {
            CameraScript.ToEND();
        }
        else if(state.RAM == true && state.Healer == true)
        {
            CameraScript.ToHEAL();
            state.level = 50;
        } else if(state.RAM == true && state.Healer == false)
        {
            CameraScript.ToRAM();
        }
        else if(state.HardDrive == true)
        {
            CameraScript.ToDRIVE();
            state.level = 5;
        }
        else
        {
            CameraScript.ToBoot();
        }
    }
    void Healer()
    {
        state.Healer = true;
    }
    void DPS()
    {
        state.DPS = true;
    }
}