using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float m_speed ;
	// Use this for initialization
	 float destory_time;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		transform.Translate(new Vector3(0,0,0));
		this.transform.Translate(new Vector3(0, m_speed,0));
//		this.transform.Translate(new Vector3(-move,0,0));

		destory_time +=Time.deltaTime;
		if(destory_time>1.0f)
		{
//			DestroyImmediate(this);
		//Destroy(this);
		}
	}


}
