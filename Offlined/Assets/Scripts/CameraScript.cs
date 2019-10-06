using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	Transform CameraTarget;
	float UpperLimit;
	float LowerLimit;
	float YCoord;
	
	void Update(){
		if (CameraTarget !=null){
			this.transform.position = new Vector2(CameraTarget.position.x, YCoord);
		}
		if (this.transform.position.x <LowerLimit)
				this.transform.position = new Vector2(LowerLimit,this.transform.position.y);
			if (this.transform.position.x > UpperLimit)
				this.transform.position = new Vector2(UpperLimit,this.transform.position.y);
	}
	public void ToStreet(Transform PlayerTransform){
		CameraTarget = PlayerTransform;
		LowerLimit = 0.63f;
		UpperLimit = 2.23f;
		YCoord = -4.0f;
	}
	public void ToProtagRoom(){
		CameraTarget = null;
		this.transform.position = new Vector2(0,0);
	}
}
