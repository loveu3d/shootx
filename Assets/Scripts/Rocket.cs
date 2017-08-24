using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
	public Transform m_bullet;

//   Transform now_bullet;

	public float m_bulletTime;

	public float move;

	GameObject endPoint;

	// Use this for initialization
	void Start () {
		this.transform.localPosition =	GameObject.Find("StartPoint").transform.localPosition;	
		endPoint = GameObject.Find("EndPoint");
		m_bulletTime=0f;
	}
	
	// Update is called once per frame
	void Update () {

		m_bulletTime -=Time.deltaTime;

		if(m_bulletTime<0)
		{
		if(Input.GetKey(KeyCode.Space)||Input.GetMouseButton(0))	
		{
				m_bulletTime=1.0f;

//			Debug.Log("First Step");

			//	now_bullet=
				GameObject obj = GameObject.Find("firePoint");

				Instantiate(m_bullet,obj.transform.position,obj.transform.rotation);


			//	now_bullet.transform.Translate(new Vector3(0,0,0));
		}

		}


		this.transform.Translate(move,0,0);

		if(this.transform.localPosition.x>endPoint.transform.localPosition.x)
		{
//			this.transform.localPosition = new Vector3(-6.5f,this.transform.position.y,this.transform.position.z);
			m_bulletTime=0f;

			this.transform.localPosition =	GameObject.Find("StartPoint").transform.localPosition;	
//					this.transform.position.y,
//					this.transform.position.z),1.0f*Time.deltaTime);
		}

	}


}
