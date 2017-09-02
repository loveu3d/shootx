using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRotate : MonoBehaviour {
	int type =1;
	// Use this for initialization
	void Start () {
		
	}

	void set_type(int _type)
	{
		type = _type;
	}
	/// <summary>
	///     The rotation speed.
	/// </summary>
	private float rotationSpeed = 330F;

	/// <summary>
	///     The rotation axis.
	/// </summary>
	public Vector3 rotationAxis = Vector3.up;

	/// <summary>
	///     Rotates this game object's transform with the given speed around axis.
	/// </summary>
	public void Update() {
		//			Debug.Log("000000000");
		if(type==1)
		{
		transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
		}else{

		}

	}
}
