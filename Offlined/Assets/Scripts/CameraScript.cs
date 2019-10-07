using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera c;
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
        c.orthographicSize = 0.6037308f;
        CameraTarget = null;
		this.transform.position = new Vector2(0,0.299f);
	}
    public void ToPark()
    {
        CameraTarget = null;
        this.transform.position = new Vector2(0, -2.544f);
    }
    public void ToBar()
    {
        CameraTarget = null;
        this.transform.position = new Vector2(0, -1.046f);
    }
    public void ToBoot()
    {
        c.orthographicSize = 0.6944343f;
        CameraTarget = null;
        this.transform.position = new Vector2(2, -1f);
        timer = Time.time + 5;
    }
    public void ToEND()
    {
        c.orthographicSize = 1.605698f;
        CameraTarget = null;
        this.transform.position = new Vector2(17, -1f);
        timer = Time.time + 5;
    }
    public void ToRAM()
    {
        c.orthographicSize = 1.605698f;
        CameraTarget = null;
        this.transform.position = new Vector2(9, -1f);
        timer = Time.time + 5;
    }
    public void ToHEAL()
    {
        c.orthographicSize = 1.605698f;
        CameraTarget = null;
        this.transform.position = new Vector2(13, -1f);
        timer = Time.time + 5;
    }
    public void ToDRIVE()
    {
        c.orthographicSize = 1.605698f;
        CameraTarget = null;
        this.transform.position = new Vector2(5, -1f);
        timer = Time.time + 5;
    }
}
