using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerRL : MonoBehaviour
{
	public float speed = 1.0f;
	Rigidbody2D Rigidbody;
	public Animator Animator;
	public CameraScript CameraScript;
	
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
	}
	//Changing positions inside Real world.
	void ToStreet(){
		CameraScript.ParentToObject(this.transform);
		transform.localPosition = new Vector2(0,-4);
	}
}