using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerVR : MonoBehaviour
{
	public float speed = 1.0f;
	Rigidbody2D Rigidbody;
	public Animator Animator;

	
    // Start is called before the first frame update
    void Start()
    {
		Rigidbody = GetComponent<Rigidbody2D>();
    }
	
	
    // Update is called once per frame
    void Update()
    {
		Rigidbody.velocity = new Vector2(speed*Input.GetAxis("Horizontal"),speed*Input.GetAxis("Vertical"));
		
		if (Input.GetAxis("Horizontal")<0){
			transform.localScale = new Vector2(-1,1);
			Animator.SetInteger("X", -1);
		}
		if (Input.GetAxis("Horizontal")>0){
			transform.localScale = new Vector2(1,1);
			Animator.SetInteger("X", 1);
		}
		if (Input.GetAxis("Horizontal")==0){
			Animator.SetInteger("X", 0);
		}
		if (Input.GetAxis("Vertical")==0){
			Animator.SetInteger("Y", 0);
		}
		if (Input.GetAxis("Horizontal")<0){
			Animator.SetInteger("Y", -1);
		}
		if (Input.GetAxis("Horizontal")>0){
			Animator.SetInteger("Y", 1);
		}		
	}
	
}