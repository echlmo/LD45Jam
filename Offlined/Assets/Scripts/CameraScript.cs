using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	Transform CameraTarget;
	float UpperLimit;
	float LowerLimit;
	float YCoord;
    float timer = 0;
    void Start()
    {
        ToBoot();
    }

	void Update(){
        if (CameraTarget != null)
        {
            this.transform.position = new Vector2(CameraTarget.position.x, YCoord);

            if (this.transform.position.x < LowerLimit)
                this.transform.position = new Vector2(LowerLimit, this.transform.position.y);
            if (this.transform.position.x > UpperLimit)
                this.transform.position = new Vector2(UpperLimit, this.transform.position.y);
        }
        if (timer != 0)
        {
            if(Time.time > timer)
            {
                ToProtagRoom();
                timer = 0;
            }
        }
    }
	public void ToStreet(Transform PlayerTransform){
		CameraTarget = PlayerTransform;
		LowerLimit = 0.63f;
		UpperLimit = 2.23f;
		YCoord = -4.0f;
	}
	public void ToProtagRoom(){
		CameraTarget = null;
		this.transform.position = new Vector2(0,0.293f);
	}
    public void ToPark()
    {
        CameraTarget = null;
        this.transform.position = new Vector2(0, -2.5f);
    }
    public void ToBar()
    {
        CameraTarget = null;
        this.transform.position = new Vector2(0, -1f);
    }
    public void ToBoot()
    {
        CameraTarget = null;
        this.transform.position = new Vector2(2, -1f);
        timer = Time.time + 5;
    }
    public void ToEND()
    {
        CameraTarget = null;
        this.transform.position = new Vector2(0, -1f);
        timer = Time.time + 5;
    }
    public void ToRAM()
    {
        CameraTarget = null;
        this.transform.position = new Vector2(9, -1f);
        timer = Time.time + 5;
    }
    public void ToHEAL()
    {
        CameraTarget = null;
        this.transform.position = new Vector2(13, -1f);
        timer = Time.time + 5;
    }
    public void ToDRIVE()
    {
        CameraTarget = null;
        this.transform.position = new Vector2(5, -1f);
        timer = Time.time + 5;
    }
}
