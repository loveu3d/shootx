using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRotateController : MonoBehaviour {
	int type =1;
	// Use this for initialization
	float rotate_ticket_2;
	void Start () {
		
	}

	public void set_type(int _type)
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

			rotate_ticket_2 +=Time.deltaTime;

			float rotate_2=50;

			if(rotate_ticket_2<0.5f)
			{
				transform.Rotate(rotationAxis, rotate_2 * Time.deltaTime);
			}else{
				transform.Rotate(rotationAxis, -rotate_2 * Time.deltaTime);

			}

		}

	}
}
