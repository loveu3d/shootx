using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void resetScores()
	{
		GameObject ui_level_id = GameObject.Find("ui_score");
		Text text =	ui_level_id.GetComponent<Text>();
		text.text ="0";
	}
	public void addScores(int scores)
	{
		GameObject ui_level_id = GameObject.Find("ui_score");
		Text text =	ui_level_id.GetComponent<Text>();
		int number = int.Parse(text.text);//	Convert.ToString(text.text);
		number+=scores;
		text.text=""+number;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void reduceLifecount()
	{
		return ;
		GameObject ui_lifetimes = GameObject.Find("ui_lifetimes");
		Text text =	ui_lifetimes.GetComponent<Text>();
		int number = int.Parse(text.text);//	Convert.ToString(text.text);
		if(number==0) return;

		number-=1;
		text.text=""+number;
	}

	public void setLifecount(int setLifecount)
	{
		return ;

		GameObject ui_lifetimes = GameObject.Find("ui_lifetimes");
		Text text =	ui_lifetimes.GetComponent<Text>();
	//	int number = int.Parse(text.text);//	Convert.ToString(text.text);
		text.text=""+setLifecount;

	}

	public int getLifecount()
	{
		return 1;

		GameObject ui_lifetimes = GameObject.Find("ui_lifetimes");
		Text text =	ui_lifetimes.GetComponent<Text>();
		int number = int.Parse(text.text);//	Convert.ToString(text.text);
		return number;
	}

}
