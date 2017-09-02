using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour {
		public Sprite[] Sprites;  
//		 float speed = 0.05f;  
//		private SpriteRenderer spriterenderer;  
//		int index;
		float interval;
		
		void Start () {
//		spriterenderer = GetComponent<SpriteRenderer>(); 
//		index=0;
	//	spriterenderer.sprite = Sprites[index];
		interval=0;
		}

		void Update () {

			interval += Time.deltaTime;
//			if(interval>speed)
//			{
//				index++;
//				interval=0;
//			}
//			spriterenderer.sprite = Sprites[index]; 

		if(interval>0.1f)
		{
			//Debug.Log(index);
			GameObject.Destroy(this.transform.parent.gameObject);
		}

	} 
		
//		void LateUpdate()
//		{
//
//
//		}


}
