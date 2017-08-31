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

	void create_stones(int indexX,int indexY,float spaceX,float spaceY,float scale_value,int life)
	{
		//注意：stones是从camera 中心生成

		for (int i=(indexX)/2;i>=0;i--)
		{
			for (int j=0;j<indexY;j++)
			{
				if(i==0&&j==0) continue;
				create_stone(i,j,spaceX,spaceY,scale_value,life);
			}
		}

		for (int i=0+1;i<(indexX)/2+1;i++)
		{
			for (int j=0;j<indexY;j++)
			{
				create_stone(-i,j,spaceX,spaceY,scale_value,life);
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
		ms.set_monster_id(id);
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

	public void resetLevel()
	{
//		level_id =4;

//		Debug.Log("debug_log");
		clear_sprites();

		float rocket_per_distatn=0.4f;//火箭移动距离 每帧
		int left_right=0;
		int up_down=0;
		float spaceX=0;
		float spaceY=0;
		float scale_value=0;
		int level_add_life=0;
		int stone_level=1;

//	level_id =5;

		//1
		switch(level_id)
		{
		case 1:
		{
				rocket_per_distatn=0.3f;
				left_right =8; //初始化左右砖数量
				up_down =3;
				spaceX= 1.5f;
				spaceY= 1.5f;
				scale_value =3f;
		}
		break;
		case 2:
		{
				rocket_per_distatn=0.32f;

				left_right =11; //初始化左右砖数量
				up_down =4;
				spaceX= 1.2f;
				spaceY= 1.2f;
				scale_value =2.5f;
		}
			break;
		case 3:
			{
				rocket_per_distatn=0.34f;

				left_right =13; //初始化左右砖数量
				up_down =5;
				spaceX= 1f;
				spaceY= 1f;
				scale_value =2f;
			}
			break;
		case 4:
			{
				rocket_per_distatn=0.36f;

				left_right =15; //初始化左右砖数量
				up_down =6;
				spaceX= 0.9f;
				spaceY= 0.8f;
				scale_value =1.75f;
			}
			break;
		case 5:
			{
				rocket_per_distatn=0.38f;

				left_right =17; //初始化左右砖数量
				up_down =8;
				spaceX= 0.8f;
				spaceY= 0.7f;
				scale_value =1.5f;
			}
			break;
		case 6:
			{
				rocket_per_distatn=0.4f;//火箭移动距离 每帧
				left_right =17; //初始化左右砖数量
				up_down =6;
				spaceX= 0.8f;
				spaceY= 0.7f;
				scale_value =1.5f;
				stone_level=2;
			}
			break;
		case 7:
			{
				rocket_per_distatn=0.48f;//火箭移动距离 每帧
				left_right =17; //初始化左右砖数量
				up_down =5;
				spaceX= 0.8f;
				spaceY= 0.7f;
				scale_value =1.5f;
				stone_level=3;
			}
			break;
			default:
			{
				rocket_per_distatn=0.48f;//火箭移动距离 每帧
				left_right =17; //初始化左右砖数量
				up_down =6;
				spaceX= 0.8f;
				spaceY= 0.7f;
				scale_value =1.5f;
				stone_level=3;
			}
			break;
		}
		create_stones(left_right,up_down,spaceX,spaceY,scale_value,stone_level);
		create_monster(left_right/2, 0 ,spaceX,spaceY,scale_value,(level_id)%10+1);
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

