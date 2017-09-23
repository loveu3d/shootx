using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using NarayanaGames.Common;
//using NarayanaGames.Common.UI;
//using NarayanaGames.ScoreFlashComponent;

public class FlySprite : MonoBehaviour {
	public GameObject effect;
	public GameObject speed;
	bool is_active;
	GameObject end;
	//	int random_pos;

	// Use this for initialization
	void Start () {
		//oldPos = transform.position; // 将最初的位置保存到oldPos  
		is_active=true;
		end= GameObject.Find("EndPoint");
	}

	public void CD_heart()
	{

		is_active=false;
		GameManager.instance.create_effect(gameObject.transform);

		GameManager.instance.setLifecount(GameManager.instance.getLifecount()+5);

		GameObject obj =	Resources.Load<GameObject>("Prefabs/SFTextYellow");
		obj = Instantiate(obj,this.transform.parent.position,gameObject.transform.parent.rotation);
		//		obj.transform.parent = this.transform.parent;
		obj.transform.SetParent(this.transform.parent);
		Text tm = obj.transform.Find("Text").GetComponent<Text>();
		int scores = 10;
		tm.text = "life +"+scores;

		TextRotateController tr = obj.GetComponent<TextRotateController>();
		tr.set_type(2);

		GameManager.instance.uiManager.addTime(scores);

//		this.gameObject. SetActive(false);

//		this.gameObject.transform.position = 	this.gameObject.transform.position +new Vector3(0,0,3);
		wait_destory();

		//比较丑的代码，位移出去，这样就被背景挡住看不见了
		this.gameObject.transform.position = 	this.gameObject.transform.position +new Vector3(0,0,3);

//		SpriteRenderer sp = this.gameObject.GetComponent<SpriteRenderer>();
//		sp.enabled = false;

	}

	void wait_destory()
	{
		StartCoroutine(WaitAndDestory(1.0F));  

	}

	//	private ScoreMessage msg;



	//StartCoroutine(WaitAndPrint(2.0F));  

	//定义 WaitAndPrint（）方法  
	IEnumerator WaitAndDestory(float waitTime)  
	{  


		yield return new WaitForSeconds(waitTime);  
//		Debug.Log("DEEsssstry");
		//等待之后执行的动作  Ï
		GameObject.Destroy(this.transform.parent.gameObject);
	}    

	// Update is called once per frame  
	float radian = 0; // 弧度  
	float perRadian = 0.03f; // 每次变化的弧度  
	float radius = 0.05f; // 半径  
	float move_distant=0.05f;
	// Update is called once per frame  
	void Update () {
//		return;
		if(is_active)
		{
		radian += perRadian; // 弧度每次加0.03  
		float dy = Mathf.Cos(radian*10) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以  
			this.transform.parent.transform.position = this.transform.parent.transform. position  + new Vector3 (move_distant, dy, 0); 

			if( this.transform. position.x>end.transform.position.x)
			{
				wait_destory();
			}
		}
		
	}

}
