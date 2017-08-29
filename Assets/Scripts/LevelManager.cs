using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//生成新关卡
//设置sprite
public class LevelManager : MonoBehaviour {
	public GameObject stone;
//	public GameObject monster;

	GameObject stone_point;
	int level_id;
	// Use this for initialization
	void Start () {


		level_id=1;
		stone_point = GameObject.Find("level_stonepoint");


	}

	// Update is called once per frame
	void Update () {

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
		for (int i=0;i<indexX;i++)
		{
			for (int j=0;j<indexY;j++)
			{
				create_stone(i,j,spaceX,spaceY,scale_value,life);
			}
		}
	}

	void create_stone(int indexX,int indexY,float spaceX,float spaceY,float scale_value,int life)
	{
		GameObject obj = Instantiate(stone,stone_point.transform.position,stone_point.transform.rotation);
		obj.transform.localScale = stone_point.transform.localScale + new Vector3(scale_value,scale_value,1);
		obj.transform.position= stone_point.transform.position +new Vector3(indexX*spaceX,-indexY*spaceY,0);

		StoneSprite sp =obj.GetComponent<StoneSprite>();
//		sp.set_life(life);
		GameObject obj2 = GameObject.Find("Stones");
		obj.transform.parent = obj2.transform;

	}

	public void create_monster(int indexX,int indexY,float spaceX,float spaceY,float scale_value,int id)
	{
		GameObject monster =	Resources.Load<GameObject>("Prefabs/CageMonster");
		monster= Instantiate(monster,stone_point.transform.position,stone_point.transform.rotation);
		//obj.transform.localScale = stone_point.transform.localScale + new Vector3(scale_value,scale_value,1);
		monster.transform.position= stone_point.transform.position +new Vector3(indexX*spaceX,-indexY*spaceY,0);

	}

	public void nextLevel()
	{
		level_id++;
		resetLevel();
	}

	public void resetLevel()
	{

		Debug.Log("debug_log");
		clear_sprites();
//		GameObject obj= new GameObject("stones");
		{
		int left_right =10;
		int up_down =1;
		float spaceX= 1.2f;
		float spaceY= 1f;
		float scale_value =0.2f;

		create_stones(left_right,up_down+level_id,spaceX,spaceY,scale_value,1);
		create_monster(left_right/2, -1 ,spaceX,spaceY,scale_value,1);

		}
		return;


		switch(level_id)
		{
			case 1:
			{
			int left_right =10;
			int up_down =2;
			float spaceX= 1.2f;
			float spaceY= 1f;
			float scale_value =0.2f;

				create_stones(left_right,up_down+level_id,spaceX,spaceY,scale_value,1);
			}
			break;
			default:
			{
//			int left_right =5;
//			int up_down =6;
//			float spaceX= 2f;
//			float spaceY= 1f;
//			float scale_value =0.2f;
//
//			create_stones(left_right,up_down,spaceX,spaceY,scale_value,1);
				int left_right =10;
				int up_down =2;
				float spaceX= 1.2f;
				float spaceY= 1f;
				float scale_value =0.2f;

				create_stones(left_right,up_down,spaceX,spaceY,scale_value,1);
			}
			break;
		}
	}

	public void enterGame1()
	{

	}
	public void enterGame2()
	{

	}
}

