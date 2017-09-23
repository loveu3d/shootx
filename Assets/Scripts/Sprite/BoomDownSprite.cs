
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using NarayanaGames.Common;
//using NarayanaGames.Common.UI;
//using NarayanaGames.ScoreFlashComponent;

public class BoomDownSprite : MonoBehaviour {
//	public GameObject effect;
//	public GameObject speed;
//	public GameObject boom;

//	public Sprite[] sprites;
//	private SpriteRenderer spriterenderer;  
//
//	 public int life=1;
//	public void set_life(int _life)
//	{
//		life=_life;
//		refreshSprite(life);
//	}

//	int random_pos;
	
	// Use this for initialization
	void Start () {
	//	random_pos=Random.Range(1,100);
//		spriterenderer = GetComponent<SpriteRenderer>();  
//		refreshSprite(life);

		//oldPos = transform.position; // 将最初的位置保存到oldPos  
	}

//	void refreshSprite(int life)
//	{
//		if(life==0) return;
//
//		int index = life-1;
//
//		if(spriterenderer==null)
//			spriterenderer = GetComponent<SpriteRenderer>();  
//		
//		spriterenderer.sprite = sprites[index];  
//
//	}
//
//
//	public void CD_stone()
//	{
//		if(life!=4)
//		life--;
//
//		refreshSprite(life);
//
//		GameManager.instance.create_effect(gameObject.transform);
//
//		if(life==0)
//		{
//			GameObject.Destroy(this.gameObject);
//		}
//	}
//
//	//关卡结束，消失动画
//	public void CD_Heart_stone()
//	{
//		
//		GameManager.instance.create_effect(gameObject.transform);
////		Instantiate(effect,gameObject.transform.position,gameObject.transform.rotation);
//
//		this.gameObject.SetActive(false);
//
//		//创建字体
////		GameObject obj = Resources.Load("Prefabs/text_3d")
//		float normal =1;
//
//		GameObject obj =	Resources.Load<GameObject>("Prefabs/SFTextYellow");
//		obj = Instantiate(obj,this.transform.position,gameObject.transform.rotation);
//		if(GameManager.instance.levelManager.is_boss_level) normal=0.5f;
//		obj.transform.localScale =new Vector3(normal,normal,normal);
////		obj.transform.parent = this.transform.parent;
//		obj.transform.SetParent(this.transform.parent);
//	
//
//	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("other.tag=="+other.tag);
		if(other.tag.CompareTo("rocket") == 0)
		{
			Debug.Log("sfsssssssssssssss");

			int reduce_count =5;
			for(int i=0;i<reduce_count;i++)
			{
			GameManager.instance.reduceLifecount();
			}
			GameManager.instance.uiManager.addTime(-2f);

//			int count =GameManager.instance.getLifecount();
//			GameManager.instance.setLifecount(count-reduce_count);

			destory_boom();
		}

	}
	public void destory_boom()
	{
		GameObject.Destroy(this.gameObject);

		GameManager.instance.create_effect(gameObject.transform);
	}

	//StartCoroutine(WaitAndPrint(2.0F));  

//定义 WaitAndPrint（）方法  
	IEnumerator WaitAndDestory(float waitTime)  
	{
	yield return new WaitForSeconds(waitTime);  
	//等待之后执行的动作  
		GameObject.Destroy(this.gameObject);
	}

	float kill_time=10.0f;
	float time_ticket;
	// Update is called once per frame  
	void FixedUpdate ()
	{
		
		time_ticket+=Time.deltaTime;

		if(time_ticket>kill_time)
		{
			GameObject.Destroy(this.gameObject);
		}

		transform.Translate(new Vector3(0,-0.035f,0));

	}


}
