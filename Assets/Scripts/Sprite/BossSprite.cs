using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using NarayanaGames.Common;
//using NarayanaGames.Common.UI;
//using NarayanaGames.ScoreFlashComponent;

public class BossSprite : MonoBehaviour {
	
	private SpriteRenderer spriterenderer;  

	 Sprite[] sprites;

	int boss_id;

//	bool is_game_win;
	float move_time;

	int life=10;
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

//		spriterenderer = this.gameObject.GetComponent<SpriteRenderer>();
//		Sprite _sprite = Resources.Load<Sprite>("monster"+monster_id);
//		spriterenderer.sprite = _sprite;


		//old_transform = this.transform.parent.transform.position;
//		is_game_win=false;
		move_time=0;
	}


//	public void StartMoveD()
//	{
//		GameManager.instance.set_gamewin(true);
//
//		GameManager.instance.reset_level_data();
//
//		GameObject object2 = GameObject.Find("boomDownSprite");
//		GameObject.Destroy(object2);
//
//		//	Debug.Log("StartMove");
//	}

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

			GameObject object2 = GameObject.Find("boomDownSprite");
			GameObject.Destroy(object2);
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

		int random_8=14;
		for(int i=0;i<random_8;i++)
		{
			int ran_time = Random.Range(1,15);
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

	float state_ticket;
	float state_normal_time=1.0f;
	float state_boom_count=1;
	float state_boom_time=1.0f;
	bool has_create_boom=false;
	int state;

	// Update is called once per frame  
	void FixedUpdate ()
	{
		//		Debug.Log(""+this.gameObject.name+": random_pos:"+random_pos);
		if(GameManager.instance.Is_game_win())
		{
			move_time +=Time.deltaTime;
			if(move_time>1.0)
			{
				//不显示这个面片
				SpriteRenderer sp =this.gameObject.GetComponent<SpriteRenderer>();
				sp.enabled = false;
//				this.gameObject.transform.position = 	this.gameObject.transform.position +new Vector3(0,0,3);
	
			}
		   if(move_time>2.5)
		   {
				EnterNextLevel();
	    	}

		}else{
			update_movement();
		
			//

			state_ticket+=Time.deltaTime;

			if(state==0)
			{
				if(state_ticket>state_normal_time)
				{
					state=1;
					state_ticket=0;
				}
			}else if(state==1){
				
//				if(state_ticket>state_boom_time-1)
//				{
//
//				}
				if(state_ticket>state_boom_time/2&&has_create_boom==false)
				{
					has_create_boom=true;

					create_boom_down();

				}
				if(state_ticket>state_boom_time)
				{
					state=0;
					state_ticket=0;
					has_create_boom=false;
				}

			}
			update_animation();

		}
	}

	void create_boom_down()
	{
//		for(int i=0;i<state_boom_count;i++)
//		{
		//有bug会同时创建
//			StartCoroutine(WaitAndCreateBoomSprite(0.5f));
//		}

		GameObject boomEffect;
		boomEffect=Instantiate(ResourcesManager.instance.boomDownSprite,gameObject.transform.position,gameObject.transform.rotation);
		boomEffect.name="boomDownSprite";
	}

	//定义 WaitAndPrint（）方法  
	IEnumerator WaitAndCreateBoomDownSprite(float waitTime)  
	{
		yield return new WaitForSeconds(waitTime);  
		//等待之后执行的动作  
		GameObject boomEffect;

		boomEffect=Instantiate(ResourcesManager.instance.boomDownSprite,gameObject.transform.position,gameObject.transform.rotation);
		boomEffect.name="boomDownSprite";
	}

	void update_animation()
	{
		if(spriterenderer==null)
					spriterenderer = GetComponent<SpriteRenderer>();  
		if(	sprites==null)
		{
			sprites = new Sprite[2];
			for(int i=0;i<2;i++)
			{
				sprites[i]= Resources.Load<Sprite>("monster"+boss_id+"_"+i);
			}
		}
			
		if(state==0)
		{
			spriterenderer.sprite = sprites[0];  

		}else if(state==1){
			spriterenderer.sprite = sprites[1];  

		}
	}


	float radian = 0; // 弧度  
	float perRadian = 0.01f; // 每次变化的弧度  float
	float radius = 0.03f; // 半径  


	void update_movement()
	{
		//move example
		radian += perRadian; // 弧度每次加0.03  
		float dy = Mathf.Cos(radian*(float)1) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以  
		this.transform.position = this.transform. position  + new Vector3 (dy, 0, 0);  
	}


	void EnterNextLevel()
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

	void ChangeDistant(int var)
	{
//		int dir =1;
//		if(var>180&&var<360)
//			dir=-1;
//
//		return dir
	}

}
