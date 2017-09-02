using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageSprite : MonoBehaviour {
	public GameObject effect;
	public GameObject speed;
	// Use this for initialization
	GameObject temp;
	void Start () {
		
	}




	private void ShowB()
	{
	}

	public void CD_monster()
	{
		int random = Random.Range(1,4);
		string str="" ;
		switch(random)
		{
		case 1: str ="Nice"; break;
		case 2:str ="Good"; break;
		case 3: str ="Awesome"; break;
		}
		ScoreFlash.Push(str);


		//隐藏石头
		GameObject obj4= GameObject.Find("heart_CD");
		HeartCD hh= obj4.GetComponent<HeartCD>();
		hh.set_HeartCD();

		//声音
		GameManager.gameManager.soundManager.PlaySound("boom");
		GameManager.gameManager.soundManager.PlayWin();

		//特效放大播放
		temp = Instantiate(effect,gameObject.transform.position,gameObject.transform.rotation);
		temp.transform.localScale = temp.transform.localScale *2;//new Vector3();

		Instantiate(speed,gameObject.transform.position+new Vector3(0,-0.3f,0),gameObject.transform.rotation);

		//				//操作怪物
		GameObject cageMonster = this.transform.parent.gameObject;
		GameObject monsterObject = cageMonster.transform.FindChild("Monster").gameObject;
		MonsterSprite ms = monsterObject.GetComponent<MonsterSprite>();
		ms.StartMove();
		//				//显示对话框
		GameObject talkObject = cageMonster.transform.FindChild("Talk").gameObject;
		TalkSprite talk = talkObject.GetComponent<TalkSprite>();
		talk.showTalk();

		//销毁笼子
		GameObject.Destroy(this.gameObject);
		//				this.gameObject.transform.position = 	this.gameObject.transform.position +new Vector3(0,0,3);
		//				StartCoroutine(WaitAndDestory(1.0F)); 
	}

//	void OnTriggerEnter(Collider other)
//	{
//		if(other.tag.CompareTo("bullet") == 0)
//		{
//			{
//				CD_monster();
//			}
//		}
//	}

	
	float radian = 0; // 弧度  
	float perRadian = 0.03f; // 每次变化的弧度  
	float radius = 0.002f; // 半径  

	// Update is called once per frame  
	void Update () {
		radian += perRadian; // 弧度每次加0.03  
		float dy = Mathf.Cos(radian*10) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以  
		this.transform.position = this.transform. position  + new Vector3 (dy, 0, 0); 
	}


}
