using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSprite : MonoBehaviour {
	
	bool is_move;
	float move_time;
//	Vector3 old_transform;

	void Start () {
		//old_transform = this.transform.parent.transform.position;
		is_move=false;
		move_time=0;
		int a=0;
		int b=0;
		a=b;
		b=a;
	}
//	public void reset_position()
//	{
////		transform.parent.transform.position
//		this.transform.parent.transform.position = old_transform;
//	}
	public void set_monster_id(int monster_id)
	{
		 SpriteRenderer spriterenderer;
	     spriterenderer = this.gameObject.GetComponent<SpriteRenderer>();
		Sprite _sprite = Resources.Load<Sprite>("monster"+monster_id);
		spriterenderer.sprite = _sprite;
	}

	public void StartMove()
	{
		is_move=true;

		GameManager.gameManager.reset_level_data();

		//	Debug.Log("StartMove");
	}

	float radian = 0; // 弧度  
	float perRadian = 0.03f; // 每次变化的弧度  
	float radius = 0.002f; // 半径  

	// Update is called once per frame  
	void Update () 
	{
		if(is_move==false)
		{
		radian += perRadian; // 弧度每次加0.03  
		float dy = Mathf.Cos(radian*10) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以  
		this.transform.position = this.transform. position  + new Vector3 (dy, 0, 0); 
		}

		if(is_move == true)
		{
			move_time+=Time.deltaTime;
			if(move_time>1.0f)
			{
				transform.parent.transform.position= transform.parent.transform.position+new Vector3(0,0.1f,0);

			}
			if(move_time>2.0)
			{
				GameManager.gameManager.nextLevel();

				is_move=false;
				move_time=0;
//				reset_position();
				Destroy( transform.parent.gameObject);

			}

		}

	}


}
