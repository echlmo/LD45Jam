using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractColliderScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Other){
		transform.GetChild(0).gameObject.SetActive(true); //interact prompt on
	}
	void OnTriggerExit2D(Collider2D Other){
		transform.GetChild(0).gameObject.SetActive(false); //interact prompt off
	}
}
