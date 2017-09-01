using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCD : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log("dsffsdf");

	}

	void OnTriggerEnter(Collider other)
	{
//		Debug.Log("dsffsdf");

		if(other.tag.CompareTo("stone") == 0)
		{
			
		}

	}

}
