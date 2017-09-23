using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour {
	public GameObject effect;
	public GameObject speed;
	public GameObject boomEffect;
	public GameObject boomDownSprite;

	public static ResourcesManager instance;
	public void load()
	{
		 effect =	Resources.Load<GameObject>("Prefabs/effect");
//		Instantiate(effect,gameObject.transform.position,gameObject.transform.rotation);
		 speed =	Resources.Load<GameObject>("Prefabs/speed");
//		Instantiate(speed,gameObject.transform.position,gameObject.transform.rotation);
		boomEffect =	Resources.Load<GameObject>("Prefabs/boomEffect");
//		Instantiate(boom,gameObject.transform.position,gameObject.transform.rotation);
		boomDownSprite =	Resources.Load<GameObject>("Prefabs/boomDownSprite");

	}

	void Start () {
		instance=this;
		load();
	}

	public void Update() {
		

	}
}
