using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
	GameObject ui_progress;
	Image ui_progress_image;
	float max_time=30f;
	bool isPauseTime;
	// Use this for initialization
	void Start () {
		ui_progress = GameObject.Find("ui_progress");
		ui_progress_image = ui_progress.GetComponent<Image>();
	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate()
	{
		if(isPauseTime) return;
		if(GameManager.instance.Is_game_win()) return;
		ui_progress_image.fillAmount -=Time.deltaTime/max_time;
		if(ui_progress_image.fillAmount <=0)
		{
//			addTime(5);
		}
	}
	public void pauseTime()
	{
		isPauseTime =true;
	}
	public void startTime()
	{
		isPauseTime =false;
	}

	public void resetTime()
	{
		ui_progress_image.fillAmount =1;
	}

	public void addTime(float time)
	{
		ui_progress_image.fillAmount +=time/max_time;
	}

	public  float getTime()
	{
		return ui_progress_image.fillAmount;
	}

	public void enterGame1()
	{

	}
	public void enterGame2()
	{

	}
}

