using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCD : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.name);

		if(other.tag.CompareTo("stone") == 0)
		{
			
		}

	}

}
