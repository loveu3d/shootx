using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager gameManager;
	public static int game_id;

	SpritesManager spritesManager;
	UIManager uiManager;
	SoundManager soundManager;
	ScoresManager scoreManager;
	LevelManager levelManager;

	GameObject ui_gameover ; 
	GameObject ui_retry ; 

	void Start () {
		gameManager=this;
		game_id=1;
		ui_gameover=null;
		ui_retry=null;
		spritesManager = this.gameObject.GetComponent<SpritesManager>();
		uiManager = this.gameObject.GetComponent<UIManager>();
		soundManager = this.gameObject.GetComponent<SoundManager>();
		scoreManager = this.gameObject.GetComponent<ScoresManager>();
		levelManager = this.gameObject.GetComponent<LevelManager>();


		soundManager.PlayBg1();

		EnterGame();
	}

	public void resetLevel()
	{
		levelManager.resetLevel();
	}
	public void nextLevel()
	{
//		CageMonster
//		reset_position
		GameManager.gameManager.setLifetime(	GameManager.gameManager.getLifetime()+5);
		levelManager.nextLevel();
	}
	public int getLifetime()
	{
		return scoreManager.getLifetime();
	}

	public void setLifetime(int lifetime)
	{
		scoreManager.setLifetime(lifetime);
	}
	public void reduceLifetime()
	{
		scoreManager.reduceLifetime();
		if(scoreManager.getLifetime()<=0)
		{
			enterGameOver();
		}
	}


	public void setGameOverVisible(bool enabled)
	{
		if(ui_gameover==null) ui_gameover =	GameObject.Find("ui_gameover");
		ui_gameover.SetActive(enabled);
		if(ui_retry==null) ui_retry =	GameObject.Find("ui_retry");
		ui_retry.SetActive(enabled);	
	
		GameObject obj = GameObject.Find("light_dir");
		Light light =obj.GetComponent<Light>();

		if(enabled==true)
		{
			light.intensity=0.2f;
		}else{
			light.intensity=1.0f;
		}

		if(enabled==true)
		{
			Time.timeScale = 0;
		}else
		{
			Time.timeScale = 1;
		}

	}


	public void enterGameOver()
	{
		setGameOverVisible(true);

	}

	void Update () {	}

	void change_game_id()
	{
		if(game_id==1)
		{
			game_id=2;
		}else{
			game_id=1;
		}
	}
	public void EnterGame()
	{
		change_button_pic();
		RetryGame();
	}

	public void EnterNextGame()
	{
		change_game_id();
		EnterGame();
	}
	void change_button_pic()
	{
		GameObject obj = GameObject.Find("ui_changegame");
		Image image = obj.GetComponent<Image>();
		string path;
		if(game_id==1)
		{
			path = "sun_icon";
		}else{
			path = "moon_icon";
		}
		Sprite sprite222 =	Resources.Load<Sprite>(path);
		image.sprite =  sprite222;

	}

	public void RetryGame()
	{
		setLifetime(5);

		setGameOverVisible(false);

		resetLevel();

		changeSprites();

		changeScores();
	}

	void 	changeScores()
	{
		if(game_id==1)
		{
			uiManager.enterGame1();
		}else{
			uiManager.enterGame2();
		}

	}

	void changeSprites()
	{
		if(game_id==1)
		{
			spritesManager.enterGame1();
		}else{
			spritesManager.enterGame2();
		}
	}






}
