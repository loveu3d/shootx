using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//生成新关卡
//设置sprite
public class LevelManager : MonoBehaviour {
	public GameObject stone;
//	public GameObject monster;

//	GameObject stone_point;
	int level_id;
	//这关过关将增加的时间
	float level_to_add_time;

	void Start () {
		set_level_id(1);
//		stone_point = GameObject.Find("level_stonepoint_y");
	}

	// Update is called once per frame
	void Update () {

	}

	int get_level_id()
	{
		return level_id;
	}

	public void set_level_id(int level)
	{
		level_id =level;
		refresh_ui_level_id();
	}
	public void refresh_ui_level_id()
	{
		GameObject ui_level_id = GameObject.Find("ui_level_id");
		Text text =	ui_level_id.GetComponent<Text>();
//		int number = int.Parse(text.text);//	Convert.ToString(text.text);
		text.text=""+get_level_id();
	}


	void clear_sprites()
	{
		GameObject obj = GameObject.Find("Stones");
		for (int i = 0; i < obj.transform.childCount; i++) { 
			Destroy (obj.transform.GetChild (i).gameObject); 
		} 
		GameObject monster = GameObject.Find("CageMonster");
		Destroy(monster);

		GameObject boss = GameObject.Find("Boss");
		Destroy(boss);

		GameObject fly = GameObject.Find("Fly");
		Destroy(fly);

		GameObject boom = GameObject.Find("boomDownSprite");
		Destroy(boom);
		//MTODO 循环消除多个地雷
//		GameObject.FindGameObjectsWithTag
	}
	struct sss{
		int a_max;
		int a_life;
		int b_max;
		int b_life;
		int c_max;
		int c_life;
	} ;


	void create_stones(int indexX,int indexY,float spaceX,float spaceY,float scale_value,int life,bool is_random,bool is_boos_level)
	{
		//注意：stones是从camera 中心生成
		int _life = life;
	

		for (int i=(indexX)/2;i>=0;i--)
		{
			for (int j=0;j<indexY;j++)
			{
				if(is_random)
				{
					_life = Random.Range(1,4);
				}
				if(is_boos_level==false)
				{
				if(i==0&&j==0) continue;//只有boss关卡中间不生成jelly
				}

				create_stone(i,j,spaceX,spaceY,scale_value,_life);
			}
		}

		for (int i=0+1;i<(indexX)/2+1;i++)
		{
			for (int j=0;j<indexY;j++)
			{
				if(is_random)
				{
					_life = Random.Range(1,3);
				}

				create_stone(-i,j,spaceX,spaceY,scale_value,_life);
			}
		}

	}

	void create_stone(int indexX,int indexY,float spaceX,float spaceY,float scale_value,int life)
	{

		GameObject camera = GameObject.Find("Main Camera");//x  y
		GameObject obj3 = GameObject.Find("StartPoint");//z
		GameObject obj4 = GameObject.Find("level_stonepoint_y");//y

		GameObject obj = Instantiate(stone,new Vector3(camera.transform.position.x,camera.transform.position.y+obj4.transform.position.y,obj3.transform.position.z), camera.transform.rotation);
		obj.transform.localScale = new Vector3(scale_value,scale_value,1);
		obj.transform.position= obj.transform.position +new Vector3(-indexX*spaceX,-indexY*spaceY,0);

		StoneSprite sp =obj.GetComponent<StoneSprite>();
		sp.set_life(life);
		GameObject obj2 = GameObject.Find("Stones");
		obj.transform.parent = obj2.transform;

	}

	public void create_monster(int indexX,float indexY,float spaceX,float spaceY,float scale_value)
	{
		GameObject camera = GameObject.Find("Main Camera");//x  y
		GameObject obj3 = GameObject.Find("StartPoint");//z
		GameObject obj4 = GameObject.Find("level_stonepoint_y");//y

		GameObject monster =	Resources.Load<GameObject>("Prefabs/CageMonster");
		monster = Instantiate(monster,monster.transform.position,monster.transform.rotation);
		monster.name = "CageMonster";
		monster.transform.localScale = new Vector3(scale_value,scale_value,1);
		monster.transform.position= new Vector3(camera.transform.position.x,camera.transform.position.y+obj4.transform.position.y,obj3.transform.position.z) +new Vector3(0,-indexY*spaceY,0);
		MonsterSprite ms = monster.transform.FindChild("Monster").GetComponent<MonsterSprite>();
		ms.set_monster_animation(1);
	}

	public void nextLevel()
	{
		set_level_id(get_level_id()+1);
	

		resetLevel();
	}
	public void set_rocket_distant(float dis)
	{
		GameObject obj = GameObject.Find("rocket");
		RocketSprite _rocket = obj.GetComponent<RocketSprite>();
		_rocket.set_rocket_distant(dis);
	}
	public void set_rocket_scale(float dis)
	{
		GameObject obj = GameObject.Find("rocket");
		obj.transform.localScale =		new Vector3( dis,dis,dis);
	}

	public float get_level_to_add_time()
	{
		return level_to_add_time;
	}

	public void level_To_add_time(float _level_add_time)
	{
		level_to_add_time = _level_add_time;
	}
	public void create_boss_level()
	{
		int boss_id = ((level_id/5))%(10);//控制在0-9之间的图片
		GameObject camera = GameObject.Find("Main Camera");//x  y
		GameObject obj3 = GameObject.Find("StartPoint");//z
//		GameObject obj4 = GameObject.Find("level_stonepoint_y");//y

		GameObject monster =	Resources.Load<GameObject>("Prefabs/Boss");
		monster = Instantiate(monster,monster.transform.position,monster.transform.rotation);
		monster.name = "Boss";
//		monster.transform.localScale = new Vector3(scale_value,scale_value,1);
		monster.transform.position= new Vector3(camera.transform.position.x,
			camera.transform.position.y+1,
			obj3.transform.position.z);
		BossSprite ms = monster.transform.GetComponent<BossSprite>();
		ms.set_monster_id(boss_id);
	}
	public void create_fly_life()
	{
		GameObject camera = GameObject.Find("Main Camera");//x  y
		GameObject obj3 = GameObject.Find("StartPoint");//z
		//		GameObject obj4 = GameObject.Find("level_stonepoint_y");//y

		GameObject monster =	Resources.Load<GameObject>("Prefabs/Fly");
		monster = Instantiate(monster,monster.transform.position,monster.transform.rotation);
		monster.name = "Fly";
		//		monster.transform.localScale = new Vector3(scale_value,scale_value,1);
		monster.transform.position= 
			new Vector3(
			-2+camera.transform.position.x+obj3.transform.position.x,
			2+camera.transform.position.y+obj3.transform.position.y,
			obj3.transform.position.z);
//		BossSprite ms = monster.transform.GetComponent<BossSprite>();
//		ms.set_monster_id(boss_id);
	}



	public void EnterBossLevel()
	{
		GameManager.instance.EnterBossLevel();
		set_rocket_scale(0.6f);
	}

	//boss的下一关进入这个函数
	public void EnterNormalLevel()
	{
		GameManager.instance.EnterNormalLevel();
		set_rocket_scale(1);
	}

	public bool is_boss_level;

	int temp__=6;

	public void resetLevel()
	{
		//test boss level
//		level_id-=1;
//		level_id +=temp__;
//
		level_id=6;

		int level_per_boss =6;

		if(level_id%level_per_boss==0)//每隔level_per_boss关一个boss
		{
			is_boss_level=true;
		}else{
			is_boss_level=false;
		}

		if(is_boss_level)
		{
			EnterBossLevel();
		}
		if((level_id-1)%level_per_boss==0)//boss的下一关进入这个函数
		{
			EnterNormalLevel();
		}

		//清除 
		clear_sprites();

		//-------fly
		int fly_random = Random.Range(1,4);
		if(is_boss_level==false&&fly_random==2)
		{
			create_fly_life();
		}
		//-------fly end

		if(	is_boss_level)
		{
			create_boss_level();
		}
		float rocket_per_distatn=0.4f;//火箭移动距离 每帧
		int left_right=0;
		int up_down=0;
		float spaceX=0;
		float spaceY=0;
		float scale_value=0;
		int level_add_time=0;
		int stone_level=1;
		bool isRandom=false;

		if(is_boss_level)
		{
			rocket_per_distatn=0.4f;//火箭移动距离 每帧
			left_right =37; //初始化左右砖数量
			up_down =1;
			spaceX= 0.35f;
			spaceY= 0.5f;
			scale_value =0.75f;
			stone_level=4;
			level_add_time=10;
		}else{
		//创建普通关卡
		if(level_id>7) isRandom=true;
		switch(level_id)
		{
		case 1:
		{
				rocket_per_distatn=0.4f;
				left_right =8; //初始化左右砖数量
				up_down =3;
				spaceX= 1.5f;
				spaceY= 1.5f;
				scale_value =3f;
				level_add_time=5;
		}
		break;
		case 2:
		{
				rocket_per_distatn=0.42f;
				left_right =11; //初始化左右砖数量
				up_down =4;
				spaceX= 1.2f;
				spaceY= 1.2f;
				scale_value =2.5f;
				level_add_time=8;
		}
			break;
		case 3:
			{
				rocket_per_distatn=0.44f;
				left_right =13; //初始化左右砖数量
				up_down =5;
				spaceX= 1f;
				spaceY= 1f;
				scale_value =2f;
				level_add_time=10;
			}
			break;
		case 4:
			{
				rocket_per_distatn=0.46f;
				left_right =15; //初始化左右砖数量
				up_down =6;
				spaceX= 0.9f;
				spaceY= 0.8f;
				scale_value =1.75f;
				level_add_time=15;
			}
			break;
		case 5:
			{
				rocket_per_distatn=0.48f;
				left_right =17; //初始化左右砖数量
				up_down =8;
				spaceX= 0.8f;
				spaceY= 0.7f;
				scale_value =1.5f;
				level_add_time=10;
			}
			break;
				//6为boss
		case 7:
			{
				rocket_per_distatn=0.5f;//火箭移动距离 每帧
				left_right =17; //初始化左右砖数量
				up_down =4;
				spaceX= 0.8f;
				spaceY= 0.7f;
				scale_value =1.5f;
				stone_level=2;
				level_add_time=20;
			}
			break;
		case 8:
			{
				rocket_per_distatn=0.5f;//火箭移动距离 每帧
				left_right =17; //初始化左右砖数量
				up_down =5;
				spaceX= 0.8f;
				spaceY= 0.7f;
				scale_value =1.5f;
				stone_level=3;
				level_add_time=30;

			}
			break;

			default:
			{
				rocket_per_distatn=0.5f;//火箭移动距离 每帧
				left_right =17; //初始化左右砖数量
				up_down =6;
				spaceX= 0.8f;
				spaceY= 0.7f;
				scale_value =1.5f;
				stone_level=3;
				level_add_time=25;
			}
			break;
		}
		}

		//创建石头
		create_stones(left_right,up_down,spaceX,spaceY,scale_value,stone_level,isRandom,is_boss_level);
		//创建怪物
		if(is_boss_level==false)
		{
		create_monster(left_right/2, 0 ,spaceX,spaceY,scale_value);
		}
		//当前关卡移动距离
		set_rocket_distant(rocket_per_distatn);
		//完成当前关卡增加的命数
		level_To_add_time(level_add_time);
			
	}


	public void enterGame1()
	{

	}
	public void enterGame2()
	{

	}
}

