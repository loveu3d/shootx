using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//使用UI->Text 必须要增加头文件 UnityEngine.UI;
using UnityEngine.UI;


public class Rocket : MonoBehaviour {
	public Transform m_bullet;

//   Transform now_bullet;

	public float m_bulletTime;

	public float move;

	GameObject endPoint;

	LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		this.transform.localPosition =	GameObject.Find("StartPoint").transform.localPosition;	
		endPoint = GameObject.Find("EndPoint");
		m_bulletTime=0f;

		lineRenderer= this.gameObject.GetComponent<LineRenderer>();
		lineRenderer.SetVertexCount(5);  

	}
	


	void Update()
	{
		lineRenderer.SetPosition (0, this.transform.position+ new Vector3 (-1, 1, 0));  
		lineRenderer.SetPosition (1,this.transform.position+  new Vector3 (1, 1, 0));  
		lineRenderer.SetPosition (2,this.transform.position+  new Vector3 (1, -1, 0));  
		lineRenderer.SetPosition (3,this.transform.position+  new Vector3 (-1, -1, 0));  
		lineRenderer.SetPosition (4, this.transform.position+ new Vector3 (-1, 1, 0));  

		// Update is called once per frame\
		Ray ray = new Ray(transform.position, transform.up);  
		RaycastHit hit;  
		if(Physics.Raycast(ray, out hit, Mathf.Infinity))  
		{
			// 如果射线与平面碰撞，打印碰撞物体信息  
			Debug.Log("碰撞对象: " + hit.collider.name);  
			// 在场景视图中绘制射线  
			Debug.DrawLine(ray.origin, hit.point, Color.red); 


		}  
	}

	void FixedUpdate () {
		//为了暂停写在这里：

		m_bulletTime -=Time.deltaTime;

		if(m_bulletTime<0)
		{
			//命数量>0 才能开炮
			if((GameManager.gameManager.scoreManager.getLifetime())>0)
			{
		   if(Input.GetKey(KeyCode.Space)||Input.GetMouseButton(0))	
		   {
				m_bulletTime=0.5f;
					
//			Debug.Log("First Step");

			//	now_bullet=
				GameObject obj = GameObject.Find("firePoint");
				 
				Instantiate(m_bullet,obj.transform.position,obj.transform.rotation);

				GameManager.gameManager.reduceLifetime();
			//	now_bullet.transform.Translate(new Vector3(0,0,0));
		}
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
