﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSprite : MonoBehaviour {
	
//	bool is_game_win;
	float move_time;
//	Vector3 old_transform;

	void Start () {
		//old_transform = this.transform.parent.transform.position;
//		is_game_win=false;
		move_time=0;
		set_monster_animation(1);
	}

	public void set_monster_animation(int anim_id)
	{
		SpriteRenderer spriterenderer;
		spriterenderer = this.gameObject.GetComponent<SpriteRenderer>();
//		Sprite _sprite = Resources.Load<Sprite>("actor"+anim_id);
		Sprite _sprite = Resources.Load<Sprite>("actor0");

		spriterenderer.sprite = _sprite;
	}

	public void StartMove()
	{
		GameManager.instance.set_gamewin(true);

		GameManager.instance.reset_level_data();

		//	Debug.Log("StartMove");
	}

	float radian = 0; // 弧度  
	float perRadian = 0.03f; // 每次变化的弧度  
	float radius = 0.002f; // 半径  

	// Update is called once per frame  
	void Update () 
	{
		if(	GameManager.instance.Is_game_win()==false)
		{
		radian += perRadian; // 弧度每次加0.03  
		float dy = Mathf.Cos(radian*10) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以  
		this.transform.position = this.transform. position  + new Vector3 (dy, 0, 0); 
		}

		if(	GameManager.instance.Is_game_win() == true)
		{
			move_time+=Time.deltaTime;
			if(move_time>1.0f)
			{
				transform.parent.transform.position= transform.parent.transform.position+new Vector3(0,0.25f,0);

			}
			if(move_time>2.0)
			{
				next_level();
			}

		}

	}

	void next_level()
	{
		GameManager.instance.nextLevel();

		GameObject obj = GameObject.Find("rocket");
		RocketSprite _rocket = obj.GetComponent<RocketSprite>();
		_rocket.reset_position();

		GameManager.instance.set_gamewin(false);
		move_time=0;
		//				reset_position();
		Destroy( transform.parent.gameObject);
	}


}
