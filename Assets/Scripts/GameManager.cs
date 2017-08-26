using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
//	public GameObject nextGame;
	public static int game_id;

	public void EnterNextGame()
	{
		Texture2D texture2d ;
		string path ;
		if(game_id==1)
		{
			path= "bg02";
			game_id=2;
		}else{
			path= "bg01";
			game_id=1;
		}
		GameObject bg =	GameObject.Find("bg");
		SpriteRenderer spr = bg.GetComponent<SpriteRenderer>(); 



		Sprite sprite222 =	Resources.Load<Sprite>(path);
		spr.sprite =sprite222;

//Sprite sp = Sprite.Create(texture2d,spr.sprite.textureRect,spr.sprite.pivot);
//		texture2d = (Texture2D)Resources.Load("bg02") as Texture2D;
//		spr.sprite = sp;


	}
	// Use this for initialization
	void Start () {
		game_id=1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
