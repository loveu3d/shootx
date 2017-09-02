using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using NarayanaGames.Common;
//using NarayanaGames.Common.UI;
//using NarayanaGames.ScoreFlashComponent;

public class StoneSprite : MonoBehaviour {
	public GameObject effect;
	public GameObject speed;

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

	public void CD_stone()
	{
		life--;

		refreshSprite(life);

		Instantiate(effect,gameObject.transform.position,gameObject.transform.rotation);
		Instantiate(speed,gameObject.transform.position,gameObject.transform.rotation);

		if(life==0)
		{


			GameObject.Destroy(this.gameObject);

			//				this.gameObject.transform.position = 	this.gameObject.transform.position +new Vector3(0,0,3);
			//				StartCoroutine(WaitAndDestory(1.0F));  

		}
	}

//	private ScoreMessage msg;

	public void CD_Heart_stone()
	{
//		Debug.Log("1234");
		Instantiate(effect,gameObject.transform.position,gameObject.transform.rotation);

		this.gameObject.SetActive(false);

		//创建字体
//		GameObject obj = Resources.Load("Prefabs/text_3d")

		GameObject obj =	Resources.Load<GameObject>("Prefabs/SFTextYellow");
		obj = Instantiate(obj,this.transform.position,gameObject.transform.rotation);
//		obj.transform.parent = this.transform.parent;
		obj.transform.SetParent(this.transform.parent);
		Text tm = obj.transform.Find("Text").GetComponent<Text>();
		int scores = 10*life;
		switch(life)
		{
		case 1:
			{ tm.color =Color.green; //
			
			}
			break;
		case 2 :
			{ tm.color =Color.yellow; }
			break;
		case 3:	
			{ tm.color =Color.green; }
			break;
		}

		tm.text = ""+scores;

		GameManager.gameManager.scoreManager.addScores(scores);

//		PushForTesting("I could be sayin' somethin'!");
//		msg = ScoreFlash.Instance.PushWorld(GetComponent<ScoreFlashFollow3D>(), "Bumping");
//		ScoreFlash.Push("");
		//		ScoreFlash.Push("+"+tm.text);

//			. Push("+"+tm.text); // <--- this is all there is to it!!!

	}
	void OnTriggerEnter(Collider other)
	{
//		Debug.Log("123");

		if(other.tag.CompareTo("heart_CD") == 0)
		{
			CD_Heart_stone();
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
