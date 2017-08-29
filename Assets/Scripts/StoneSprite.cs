using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSprite : MonoBehaviour {
	public GameObject effect;


	public Sprite[] sprites;
	private SpriteRenderer spriterenderer;  

	 public int life=1;
	public void set_life(int _life)
	{
		life=_life;
		refreshSprite(life);
	}

//	int random_pos;
	
	// Use this for initialization
	void Start () {
	//	random_pos=Random.Range(1,100);
		spriterenderer = GetComponent<SpriteRenderer>();  
		refreshSprite(life);

		//oldPos = transform.position; // 将最初的位置保存到oldPos  
	}

	void refreshSprite(int life)
	{


		if(life==0) return;

		int index = life-1;

		if(spriterenderer==null)
			spriterenderer = GetComponent<SpriteRenderer>();  
		
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


				GameObject.Destroy(this.gameObject);

//				this.gameObject.transform.position = 	this.gameObject.transform.position +new Vector3(0,0,3);
//				StartCoroutine(WaitAndDestory(1.0F));  

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



//	float radian = 0; // 弧度  
//	float perRadian = 0.03f; // 每次变化的弧度  float
//	float radius = 0.02f; // 半径  

	// Update is called once per frame  
	void Update () {
//		radian += perRadian; // 弧度每次加0.03  
//		float dy = Mathf.Cos(radian*(float)15) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以  
//		this.transform.position = this.transform. position  + new Vector3 (dy, 0, 0);  
//		Debug.Log(""+this.gameObject.name+": random_pos:"+random_pos);


	}

}
