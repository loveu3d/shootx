using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
	public GameObject effect;
	// Use this for initialization
	GameObject temp;
	void Start () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag.CompareTo("bullet") == 0)
		{
			{
				temp = Instantiate(effect,gameObject.transform.position,gameObject.transform.rotation);
				temp.transform.localScale = temp.transform.localScale *2;//new Vector3();

				GameObject.Destroy(this.gameObject);

				//				this.gameObject.transform.position = 	this.gameObject.transform.position +new Vector3(0,0,3);
				//				StartCoroutine(WaitAndDestory(1.0F)); 
			}
		}
	}

	
	float radian = 0; // 弧度  
	float perRadian = 0.03f; // 每次变化的弧度  
	float radius = 0.002f; // 半径  

	// Update is called once per frame  
	void Update () {
		radian += perRadian; // 弧度每次加0.03  
		float dy = Mathf.Cos(radian*10) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以  
		this.transform.position = this.transform. position  + new Vector3 (dy, 0, 0); 
	}


}
