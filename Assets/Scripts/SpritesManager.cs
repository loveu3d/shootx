using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void enterGame1()
	{
		changeBG();
		clearGame2();
		initWithGame1(0);
	}

	public void enterGame2()
	{
		changeBG();
		clearGame1();
		initWithGame2(0);
	}

	public void initWithGame1(int level_id)
	{

	}

	public void clearGame1()
	{

	}



	public void initWithGame2(int level_id)
	{

	}

	public void clearGame2()
	{

	}

	void changeMonster()
	{

	}

	void changeBG()
	{
//		Texture2D texture2d ;
		string path ;
		if(GameManager.game_id==1)
		{
			path= "bg02";
		}else{
			path= "bg01";
		}
		GameObject bg =	GameObject.Find("bg");
		SpriteRenderer spr = bg.GetComponent<SpriteRenderer>(); 

		Sprite sprite222 =	Resources.Load<Sprite>(path);
		spr.sprite =sprite222;

	}
}
