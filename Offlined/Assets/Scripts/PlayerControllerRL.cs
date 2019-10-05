using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRL : MonoBehaviour
{
	
	CharacterController CharacterController;
	public float speed = 6.0f;
	
	
    // Start is called before the first frame update
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }
	
	
    // Update is called once per frame
    void Update()
    {
        CharacterController.Move( new Vector3(Input.GetAxis("Horizontal")*speed*Time.deltaTime,0.0f,0.0f));
    }
	
	
}
