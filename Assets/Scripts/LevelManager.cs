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
	//这关过关将增加的命
	int level_to_add_life;

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

	}
	struct sss{
		int a_max;
		int a_life;
		int b_max;
		int b_life;
		int c_max;
		int c_life;
	} ;


	void create_stones(int indexX,int indexY,float spaceX,float spaceY,float scale_value,int life,bool is_random)
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

				if(i==0&&j==0) continue;
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

	public void create_monster(int indexX,float indexY,float spaceX,float spaceY,float scale_value,int id)
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
		ms.set_monster_animation(id);
	}

	public void nextLevel()
	{
		set_level_id(get_level_id()+1);
	

		resetLevel();
	}
	public void set_rocket_distant(float dis)
	{
		GameObject obj = GameObject.Find("rocket");
		Rocket _rocket = obj.GetComponent<Rocket>();
		_rocket.set_rocket_distant(dis);
	}
	public int get_level_to_add_life()
	{
		return level_to_add_life;
	}

	public void level_To_add_life(int _level_add_life)
	{
		level_to_add_life = _level_add_life;
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
		monster.transform.position= new Vector3(camera.transform.position.x,camera.transform.position.y,obj3.transform.position.z);
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

	public void resetLevel()
	{
//		level_id =5;

//		Debug.Log("debug_log");
		clear_sprites();

		int fly_random = Random.Range(1,4);
		if(fly_random==2)
		{
		create_fly_life();
		}

		int level_per_boss =5;
		if(level_id%level_per_boss==0)//每隔level_per_boss关一个boss
		{
			create_boss_level();

			return;
		}

		float rocket_per_distatn=0.4f;//火箭移动距离 每帧
		int left_right=0;
		int up_down=0;
		float spaceX=0;
		float spaceY=0;
		float scale_value=0;
		int level_add_life=0;
		int stone_level=1;

// 		level_id =8;

		//1
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
				level_add_life=4;
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
				level_add_life=8;
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
				level_add_life=10;
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
				level_add_life=15;
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
				level_add_life=20;
			}
			break;
		case 6:
			{
				rocket_per_distatn=0.5f;//火箭移动距离 每帧
				left_right =17; //初始化左右砖数量
				up_down =4;
				spaceX= 0.8f;
				spaceY= 0.7f;
				scale_value =1.5f;
				stone_level=2;
				level_add_life=25;
			}
			break;
		case 7:
			{
				rocket_per_distatn=0.5f;//火箭移动距离 每帧
				left_right =17; //初始化左右砖数量
				up_down =5;
				spaceX= 0.8f;
				spaceY= 0.7f;
				scale_value =1.5f;
				stone_level=3;
				level_add_life=30;

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
				level_add_life=25;
			}
			break;
		}
		bool isRandom=false;

		if(level_id>7) isRandom=true;

		create_stones(left_right,up_down,spaceX,spaceY,scale_value,stone_level,isRandom);

//		int monster_id = Random.Range(1,11);
		int monster_id = ((level_id-1)%(10)+1);

		create_monster(left_right/2, 0 ,spaceX,spaceY,scale_value,monster_id);

		set_rocket_distant(rocket_per_distatn);

		level_To_add_life(level_add_life);
			
	}


	public void enterGame1()
	{

	}
	public void enterGame2()
	{

	}
}

