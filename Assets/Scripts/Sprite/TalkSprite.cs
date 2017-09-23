using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkSprite : MonoBehaviour {
	bool isShow;
	float time_ticket;
	void Start () {
		time_ticket=0;
		isShow=false;
	}

	public void showTalk()
	{
		isShow=true;
	}


	// Update is called once per frame  
	void Update () {
		float time1=0.5f;
		float time2=1.0f;
		float time3=1.5f;
		if(isShow==true)
		{
			time_ticket+=Time.deltaTime;

			if(time_ticket<time1)
			{
	    	 this.transform.localScale = this.transform.localScale + new Vector3(0.01f,0.01f,1f);
			}
			if(time_ticket>time1&& time_ticket<time2)
			{
				SpriteRenderer spr = this.gameObject.GetComponent<SpriteRenderer>();
				spr.color =new Color (1,1,1,spr.color.a-0.1f); //spr.color ;
			}
		}

		if(time_ticket>time3)
		{
			time_ticket=0;
			isShow=false;

			Destroy(this.gameObject);
		}

	}


}
