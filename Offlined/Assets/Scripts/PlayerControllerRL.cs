using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerRL : MonoBehaviour
{
	public float speed = 1.0f;
	Rigidbody2D Rigidbody;
	public Animator Animator;
	public CameraScript CameraScript;
	public GameObject LeaveRoomCollider;
	public GameObject ToProtagRoomCollider;
    public GameObject GarbageCollider;
    public GameObject HardWareStoreCollider;
    public GameObject ReturnToStreetCollider;
    public GameObject ReturnLV50Collider;
    public GameObject LV50Collider;
    // Start is called before the first frame update
    void Start()
    {
		Rigidbody = GetComponent<Rigidbody2D>();
    }
	
    // Update is called once per frame
    void Update()
    {
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
            else if (LV50Collider.GetComponent<BoxCollider2D>().bounds.Contains(this.transform.position))
            {
                ToPark();
            }
            else if (HardWareStoreCollider.GetComponent<BoxCollider2D>().bounds.Contains(this.transform.position))
            {
                ToBar();
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
}