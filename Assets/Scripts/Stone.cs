using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
	public GameObject effect;


	public Sprite[] sprites;
	private SpriteRenderer spriterenderer;  

	 int life=1;

	//漂浮效果
	float radian = 0; // 弧度  
	float perRadian = 0.01f; // 每次变化的弧度  
	float radius = 0.0005f; // 半径  
	//Vector3 oldPos; // 开始时候的坐标  
	
	// Use this for initialization
	void Start () {
		spriterenderer = GetComponent<SpriteRenderer>();  
		refreshSprite(life);

		//oldPos = transform.position; // 将最初的位置保存到oldPos  
	}

	void refreshSprite(int life)
	{


		if(life==0) return;

		int index = life-1;

		spriterenderer.sprite = sprites[index];  

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag.CompareTo("bullet") == 0)
		{
			life--;

			refreshSprite(life);

			if(life==0)
			{
				Instantiate(effect,gameObject.transform.position,gameObject.transform.rotation);

				this.gameObject.transform.position = 	this.gameObject.transform.position +new Vector3(0,0,3);
//				GameObject.Destroy(this.gameObject);

				StartCoroutine(WaitAndDestory(1.0F));  

			}

		}
	}
	//StartCoroutine(WaitAndPrint(2.0F));  

//定义 WaitAndPrint（）方法  
	IEnumerator WaitAndDestory(float waitTime)  
	{  


	yield return new WaitForSeconds(waitTime);  
	//等待之后执行的动作  
		GameObject.Destroy(this.gameObject);
	}    


	// Update is called once per frame  
	void Update () {  
		radian += perRadian; // 弧度每次加0.03  
		float dy = Mathf.Cos(radian) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以  
		transform.position = transform.position  + new Vector3 (dy, 0, 0);  
	}  

}
