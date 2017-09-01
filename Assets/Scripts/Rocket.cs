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

	public void set_rocket_distant(float _move)
	{
		move = _move;
	}

	GameObject endPoint;

	LineRenderer lineRenderer;

	public void reset_position()
	{
		this.transform.localPosition =	GameObject.Find("StartPoint").transform.localPosition;	

	}

	// Use this for initialization
	void Start () {
		reset_position();
		endPoint = GameObject.Find("EndPoint");
		m_bulletTime=0f;

//		lineRenderer= this.gameObject.GetComponent<LineRenderer>();
//		lineRenderer.SetVertexCount(2);  
//		lineRenderer.SetWidth(0.05f,0.05f);
//		Color drawColor=Color.cyan;
//		switch(1)
//		{
//		case 1:
//			drawColor = Color.cyan;//青色
//			break;
//		case 2:
//			drawColor = Color.green; //绿色
//			break;
//		default:
//			drawColor = Color.clear;//擦除
//			break;
//		}
//		lineRenderer.SetColors(drawColor, drawColor); //开始、结束颜色
//


	}
	


	void Update()
	{
	//		lineRenderer.SetPosition (2,this.transform.position+  new Vector3 (1, -1, 0));  
//		lineRenderer.SetPosition (3,this.transform.position+  new Vector3 (-1, -1, 0));  
//		lineRenderer.SetPosition (4, this.transform.position+ new Vector3 (-1, 1, 0));  


	}
	public void runbullet()
	{







	}

	public bool Is_Game_win()
	{
		GameObject obj = GameObject.Find("Monster");
		MonsterSprite sprite = obj.GetComponent<MonsterSprite>();
		return sprite.Is_game_win();
	}

	void FixedUpdate () 
	{
		//为了暂停写在这里：
		m_bulletTime -=Time.deltaTime;

		// Update is called once per frame\
		Ray ray = new Ray(transform.position, transform.up);  
		RaycastHit hit;  
		if(Physics.Raycast(ray, out hit, Mathf.Infinity))  
		{
			// 如果射线与平面碰撞，打印碰撞物体信息  

			// 在场景视图中绘制射线  
			Debug.DrawLine(ray.origin, hit.point, Color.red); 

			//			lineRenderer.SetPosition (0, this.transform.position+ new Vector3 (1, 1, 0));  
			//			lineRenderer.SetPosition (1,this.transform.position+  new Vector3 (1, -1, 0));  
			//			lineRenderer.SetPosition (0,ray.origin);  
			//			lineRenderer.SetPosition (1,  hit.point+new Vector3 (0, 0, 0));  
	
			//run bullet
			if(m_bulletTime<0)
			{
				//命数量>0 才能开炮
//				Debug.Log("GameManager.gameManager:"+GameManager.gameManager);
//				Debug.Log("gameManager.scoreManager:"+GameManager.gameManager.scoreManager);

				if((GameManager.gameManager.scoreManager.getLifetime())>0)
				{
					if(Input.GetKey(KeyCode.Space)||Input.GetMouseButton(0))	
					{
						if(Is_Game_win()==false)
						{
							GameManager.gameManager.soundManager.PlaySound("biu");

						m_bulletTime=0.5f;

						//之前的碰撞检测
//						GameObject obj = GameObject.Find("firePoint");
//
//						Instantiate(m_bullet,obj.transform.position,obj.transform.rotation);
					//	Debug.Log("碰撞对象: " + hit.collider.name);  
						if(hit.collider.name =="Cage")
						{
							GameObject cage =  hit.collider.gameObject;
							cage.GetComponent<CageSprite>().CD_monster();
						}else{
							GameObject stone =  hit.collider.gameObject;
							stone.GetComponent<StoneSprite>().	CD_stone();
						}

						GameManager.gameManager.reduceLifetime();
						}

					}
				}
			}
			//run bullet

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
