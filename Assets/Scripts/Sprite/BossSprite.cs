using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using NarayanaGames.Common;
//using NarayanaGames.Common.UI;
//using NarayanaGames.ScoreFlashComponent;

public class BossSprite : MonoBehaviour {
	
	private SpriteRenderer spriterenderer;  

	int boss_id;

//	bool is_game_win;
	float move_time;

	int life=1;
	public void set_life(int _life)
	{
		life=_life;
		refreshSprite(life);
	}

	//	int random_pos;
	//	Vector3 old_transform;

	void Start () {
		//old_transform = this.transform.parent.transform.position;
		spriterenderer = GetComponent<SpriteRenderer>();  
		refreshSprite(life);

//		is_game_win=false;
		move_time=0;
	}

//	public  bool Is_game_win()
//	{
//		return is_game_win;
//	}

	//	public void reset_position()
	//	{
	////		transform.parent.transform.position
	//		this.transform.parent.transform.position = old_transform;
	//	}
	public void set_monster_id(int monster_id)
	{
		if(monster_id==0) boss_id=10;

		boss_id = monster_id;

		SpriteRenderer spriterenderer;
		spriterenderer = this.gameObject.GetComponent<SpriteRenderer>();
		Sprite _sprite = Resources.Load<Sprite>("monster"+monster_id);
		spriterenderer.sprite = _sprite;


		//old_transform = this.transform.parent.transform.position;
//		is_game_win=false;
		move_time=0;
	}


	public void StartMove()
	{
		GameManager.instance.set_gamewin(true);

		GameManager.instance.reset_level_data();

		//	Debug.Log("StartMove");
	}

	void refreshSprite(int life)
	{
		if(life==0) return;
		int index = life-1;
		if(spriterenderer==null)
			spriterenderer = GetComponent<SpriteRenderer>();  
	}

	public void CD_boss()
	{
		life--;

		refreshSprite(life);

		GameManager.instance.create_effect(gameObject.transform);

		//		GameObject lighting =	Resources.Load<GameObject>("Prefabs/lighting");
		//		lighting=Instantiate(lighting,gameObject.transform.position,gameObject.transform.rotation);
		//		lighting.transform.SetParent(effect.transform);//=this.gameObject;

		//		GameObject lighting = Instantiate(Resources.Load("Prefabs/lighting")) as GameObject; 
		//		lighting.transform.SetParent(effect.transform.parent);

		if(life==0)
		{
			GameManager.instance.create_level_end_scoreflash();

			Boss_will_die();

			GameManager.instance.set_gamewin(true);
//			ff
//			GameObject.Destroy(this.gameObject);

			//				this.gameObject.transform.position = 	this.gameObject.transform.position +new Vector3(0,0,3);
			//				StartCoroutine(WaitAndDestory(1.0F));  

		}
	}

	//	private ScoreMessage msg;

	//关卡结束，消失动画
	public void Boss_will_die()
	{


		//声音
		GameManager.instance.soundManager.PlaySound("boom");
		GameManager.instance.soundManager.PlaySound("win",0.5f);

//		float offsetY = 1.0f;
		GameManager.instance.create_effect(gameObject.transform);
		Transform _transform =gameObject.transform;
//		_transform.rotation=gameObject.transform.rotation;

		int random_8=8;
		for(int i=0;i<random_8;i++)
		{
			int ran_time = Random.Range(1,9);
			int move_x = Random.Range(1,9);
			int move_y = Random.Range(1,12);//y值大些（图片比较高）
			int rand_x_dir =1;
			int rand_y_dir =1;
			int rand_x=Random.Range(1,3);
			if(rand_x==1) rand_x_dir=-1;
			int rand_y=Random.Range(1,3);
			if(rand_y==1) rand_y_dir=-1;

			GameManager.instance.create_effect(
				_transform.position+new Vector3(((float)move_x/10f)*rand_x_dir,((float)move_y/10f)*rand_y_dir,0),_transform.rotation,(float)ran_time/10f);
		}
	

//		Instantiate(effect,gameObject.transform.position,gameObject.transform.rotation);

//		this.gameObject.SetActive(false);

		//创建字体
//		GameObject obj =	Resources.Load<GameObject>("Prefabs/SFTextYellow");
//		obj = Instantiate(obj,this.transform.position,gameObject.transform.rotation);
//		//		obj.transform.parent = this.transform.parent;
//		obj.transform.SetParent(this.transform.parent);
//		Text tm = obj.transform.Find("Text").GetComponent<Text>();
		int scores = 100*boss_id;
//		tm.color =Color.red;
//		tm.text = ""+scores;
		GameManager.instance.scoreManager.addScores(scores);

//		this.gameObject.transform.position = 	this.gameObject.transform.position +new Vector3(0,0,3);

		//隐藏石头
		GameObject obj4= GameObject.Find("heart_CD");
		HeartCDTrigger hh= obj4.GetComponent<HeartCDTrigger>();
		hh.set_HeartCD();

}


	float radian = 0; // 弧度  
	float perRadian = 0.01f; // 每次变化的弧度  float
	float radius = 0.1f; // 半径  

	// Update is called once per frame  
	void Update ()
	{
		//		Debug.Log(""+this.gameObject.name+": random_pos:"+random_pos);
		if(GameManager.instance.Is_game_win())
		{
			move_time +=Time.deltaTime;

		   if(move_time>2.0)
		   {
				GameManager.instance.nextLevel();

			GameObject obj = GameObject.Find("rocket");
				RocketSprite _rocket = obj.GetComponent<RocketSprite>();
			_rocket.reset_position();

				GameManager.instance.set_gamewin(false);
			move_time=0;
			//				reset_position();
			Destroy( transform.gameObject);

	    	}

		}else{
			radian += perRadian; // 弧度每次加0.03  
			float dy = Mathf.Cos(radian*(float)5) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以  
			this.transform.position = this.transform. position  + new Vector3 (dy, 0, 0);  


		}
	}


}
