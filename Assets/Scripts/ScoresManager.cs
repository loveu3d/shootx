using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void reduceLifetime()
	{
		GameObject ui_lifetimes = GameObject.Find("ui_lifetimes");
		Text text =	ui_lifetimes.GetComponent<Text>();
		int number = int.Parse(text.text);//	Convert.ToString(text.text);
		if(number==0) return;

		number-=1;
		text.text=""+number;
	}
	public void setLifetime(int setLifetime)
	{
		GameObject ui_lifetimes = GameObject.Find("ui_lifetimes");
		Text text =	ui_lifetimes.GetComponent<Text>();
	//	int number = int.Parse(text.text);//	Convert.ToString(text.text);
		text.text=""+setLifetime;

	}
	public int getLifetime()
	{
		GameObject ui_lifetimes = GameObject.Find("ui_lifetimes");
		Text text =	ui_lifetimes.GetComponent<Text>();
		int number = int.Parse(text.text);//	Convert.ToString(text.text);
		return number;
	}

}
