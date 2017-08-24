using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	public Sprite[] sprites;
	private SpriteRenderer spriterenderer;  

	public int life=3;
	// Use this for initialization
	void Start () {
		spriterenderer = GetComponent<SpriteRenderer>();  
		refreshSprite(life);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void refreshSprite(int life)
	{
		int index = life-1;

		spriterenderer.sprite = sprites[index];  

	}

	void OnTriggerEnter(Collider other)
	{
//		Debug.Log("OnTriggerEnter");

		if(other.tag.CompareTo("bullet") == 0)
		{
			life--;

			refreshSprite(life);

			if(life==0)
			{
			GameObject.Destroy(this.gameObject);
			}

		}
	}


}
