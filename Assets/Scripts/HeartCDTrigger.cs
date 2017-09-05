using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCDTrigger : MonoBehaviour {
	bool is_scale;
	float scale_ticket;
	// Use this for initialization
	void Start () {
		is_scale=false;
	}
	public void set_HeartCD()
	{
		is_scale=true;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log("dsffsdf");

		if(is_scale==true)
		{
			scale_ticket +=Time.deltaTime;

			float sss= 2.0f;

			if(scale_ticket>1.8f)
			{
				is_scale=false;
				scale_ticket=0;
				sss=0;
				this.transform.localScale =new Vector3(sss,sss,sss);

			}

			this.transform.localScale +=new Vector3(sss,sss,sss);

		}
	}

	void OnTriggerEnter(Collider other)
	{
//		Debug.Log("dsffsdf");

		if(other.tag.CompareTo("stone") == 0)
		{
			
		}

	}

}
