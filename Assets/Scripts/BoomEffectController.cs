using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffectController : MonoBehaviour {
	float time;
	void Start () {

	}

	/// <summary>
	///     Rotates this game object's transform with the given speed around axis.
	/// </summary>
	public void Update() {
		time+=Time.deltaTime;
		if(time>2.0f)
		{
			GameObject.Destroy(this.gameObject);
		}
	}

}

