using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAni : MonoBehaviour {
		public Sprite[] Sprites;  
		 float speed = 0.03f;  
		private SpriteRenderer spriterenderer;  
		int index;
		float interval;
		
		void Start () {
		spriterenderer = GetComponent<SpriteRenderer>(); 
		index=0;
		spriterenderer.sprite = Sprites[index];
		interval=0;
		}

		void Update () {

			interval += Time.deltaTime;
			if(interval>speed)
			{
				index++;
				interval=0;
			}
			spriterenderer.sprite = Sprites[index]; 

		if(index==Sprites.Length-1)
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
