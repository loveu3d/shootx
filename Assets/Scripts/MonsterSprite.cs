using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSprite : MonoBehaviour {
	
	bool is_move;
	float move_time;
	Transform old_transform;

	void Start () {
		is_move=false;
		move_time=0;
		old_transform = this.transform.parent.transform;
	}
	public void reset_transform()
	{
		this.transform.parent.transform.position = old_transform.position;
	}

	public void StartMove()
	{
		is_move=true;

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
			if(move_time>2.0f)
			{
				transform.parent.transform.position= transform.parent.transform.position+new Vector3(0,0.1f,0);

			}
			if(move_time>3.0)
			{
				GameManager.gameManager.nextLevel();
			}

		}

	}


}
