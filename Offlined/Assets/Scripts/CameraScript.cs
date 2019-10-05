using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public void IntoRoom(){
		this.transform.parent = null;
		this.transform.position = new Vector3(0,0,0);
	}
	public void ParentToObject(Transform Parent){
		this.transform.parent = Parent;
	}
}
