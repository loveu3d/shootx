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
		GameManager.instance.create_level_end_scoreflash();


		//隐藏石头
		GameObject obj4= GameObject.Find("heart_CD");
		HeartCDTrigger hh= obj4.GetComponent<HeartCDTrigger>();
		hh.set_HeartCD();

		//声音
		GameManager.instance.soundManager.PlaySound("boom");
		GameManager.instance.soundManager.PlaySound("win",0.5f);

		//特效放大播放
//		temp = Instantiate(effect,gameObject.transform.position,gameObject.transform.rotation);
//		temp.transform.localScale = temp.transform.localScale *2;//new Vector3();
//
//		Instantiate(speed,gameObject.transform.position+new Vector3(0,-0.3f,0),gameObject.transform.rotation);

		GameManager.instance.create_effect(gameObject.transform);

		/*
		//				//操作怪物
		GameObject cageMonster = this.transform.parent.gameObject;
		GameObject monsterObject = cageMonster.transform.FindChild("Monster").gameObject;
		MonsterSprite ms = monsterObject.GetComponent<MonsterSprite>();
		ms.set_monster_animation(2);
		ms.StartMove();
		//				//显示对话框
		GameObject talkObject = cageMonster.transform.FindChild("Talk").gameObject;
		TalkSprite talk = talkObject.GetComponent<TalkSprite>();
		talk.showTalk();
		//销毁笼子
		GameObject.Destroy(this.gameObject);
		*/

		//				this.gameObject.transform.position = 	this.gameObject.transform.position +new Vector3(0,0,3);
		//				StartCoroutine(WaitAndDestory(1.0F)); 

		GameManager.instance.set_gamewin(true);

		GameManager.instance.reset_level_data();

		GameObject cageMonster = this.transform.parent.gameObject;
		GameObject cageObject = cageMonster.transform.FindChild("Cage").gameObject;
		SpriteRenderer sr = cageObject.GetComponent<SpriteRenderer>();
		sr.enabled =false;

		wait_time=0;
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
	float radius = 0.01f; // 半径  



	// Update is called once per frame  
	void Update () {
//		radian += perRadian; // 弧度每次加0.03  
//		float dy = Mathf.Cos(radian*10) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以  
//		this.transform.position = this.transform. position  + new Vector3 (dy, 0, 0); 

		if(	GameManager.instance.Is_game_win()==false)
		{
			radian += perRadian; // 弧度每次加0.03  
			float dy = Mathf.Cos(radian*10) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以  
//			this.transform.position = this.transform. position  + new Vector3 (dy, 0, 0); 
			this.transform.localScale = this.transform.localScale + new Vector3(dy,dy,0);
		}

		if(	GameManager.instance.Is_game_win() == true)
		{
			wait_time +=Time.deltaTime;

			if(wait_time>2.0)
			{
				next_level();
			}
		}

	}

	float wait_time;

	void next_level()
	{
		GameManager.instance.nextLevel();

		GameObject obj = GameObject.Find("rocket");
		RocketSprite _rocket = obj.GetComponent<RocketSprite>();
		_rocket.reset_position();

		GameManager.instance.set_gamewin(false);
		wait_time=0;
		//				reset_position();
		Destroy( transform.parent.gameObject);
	}

}
