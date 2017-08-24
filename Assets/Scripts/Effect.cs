using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

		public Sprite[] Sprites;  
		public float speed;  
		private SpriteRenderer spriterenderer;  

		void Start () {  
			spriterenderer = GetComponent<SpriteRenderer>();  

		}  

		void Update () {  
			int index = (int)(Time.time * speed) % Sprites.Length;  
			spriterenderer.sprite = Sprites[index];  

			if(index==Sprites.Length-1)
			GameObject.Destroy(this.gameObject);
		}  


}
