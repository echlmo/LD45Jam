using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerRL : MonoBehaviour
{
	
	CharacterController CharacterController;
	public float speed = 6.0f;
	
	Rigidbody2D Rigidbody;
	
    // Start is called before the first frame update
    void Start()
    {
		Rigidbody = GetComponent<Rigidbody2D>();
    }
	
	
    // Update is called once per frame
    void Update()
    {
		Rigidbody.velocity = new Vector2(6.0f*Input.GetAxis("Horizontal"),0);
	}
	
	
}