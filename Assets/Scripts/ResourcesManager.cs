using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour {
	public GameObject effect;
	public GameObject speed;
	public GameObject boom;
	public static ResourcesManager instance;
	public void load()
	{
		 effect =	Resources.Load<GameObject>("Prefabs/effect");
//		Instantiate(effect,gameObject.transform.position,gameObject.transform.rotation);
		 speed =	Resources.Load<GameObject>("Prefabs/speed");
//		Instantiate(speed,gameObject.transform.position,gameObject.transform.rotation);
		 boom =	Resources.Load<GameObject>("Prefabs/boom");
//		Instantiate(boom,gameObject.transform.position,gameObject.transform.rotation);

	}

	void Start () {
		instance=this;
		load();
	}

	public void Update() {
		

	}
}
