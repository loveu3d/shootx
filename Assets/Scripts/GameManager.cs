using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public static int game_id;

	SpritesManager spritesManager;
	public UIManager uiManager;
	public SoundManager soundManager;
	public ScoresManager scoreManager;
	public LevelManager levelManager;

	GameObject ui_gameover ; 
	GameObject ui_retry ; 
	public bool will_game_over;
	public float will_game_time=1.0f;
	public float will_game_ticket;

	bool is_game_win;

	void Start () {
		instance=this;

		game_id=1;
		will_game_time=1.0f;



		ui_gameover=null;
		ui_retry=null;
		spritesManager = this.gameObject.GetComponent<SpritesManager>();
		uiManager = this.gameObject.GetComponent<UIManager>();
		soundManager = this.gameObject.GetComponent<SoundManager>();
		scoreManager = this.gameObject.GetComponent<ScoresManager>();
		levelManager = this.gameObject.GetComponent<LevelManager>();


		EnterGame();
	}

	public void CreateEffect()
	{

	}

	public void reset_level_data()
	{
		will_game_over=false;
		will_game_ticket=0;

	}

	public void resetLevel()
	{
		levelManager.resetLevel();
	}
	public void nextLevel()
	{
		reset_level_data();

//		CageMonster
//		reset_position
		GameManager.instance.setLifetime(	GameManager.instance.getLifetime()
			+levelManager. get_level_to_add_life());
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

	public bool Is_game_win()
	{
		return is_game_win;
	}
	public void set_gamewin(bool sss)
	{
		is_game_win = sss;
	}
	public void reduceLifetime()
	{
		scoreManager.reduceLifetime();
		if(scoreManager.getLifetime()<=0)
		{
//			GameObject obj = GameObject.Find("Monster");
//			MonsterSprite sprite = obj.GetComponent<MonsterSprite>();
			if(Is_game_win()) return; 
			will_game_over=true;
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

	void Update () {	
	
		if(will_game_over==true)
		{
			will_game_ticket +=Time.deltaTime;
			if(will_game_time<will_game_ticket)
			{
			enterGameOver();
			}
		}
	}

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
		soundManager.PlayBGM("bgm");
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
		reset_level_data();

		levelManager.set_level_id(1);

		GameManager.instance.scoreManager.resetScores();

		setLifetime(20);

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


	//创建击打特效
	public void create_effect(Transform transform)
	{
		create_effect(transform.position,transform.rotation,0);
	}
	public void create_effect(Vector3 pos,UnityEngine.Quaternion rotat,float delay)
	{
		if(delay==0)
		{
		float offset_z = -2.5f;//最前显示
		//		GameObject effect =	Resources.Load<GameObject>("Prefabs/effect");
			Instantiate(ResourcesManager.instance.effect,pos,rotat);
		//		GameObject speed =	Resources.Load<GameObject>("Prefabs/speed");
			Instantiate(ResourcesManager.instance.speed,pos,rotat);
		//		GameObject boom =	Resources.Load<GameObject>("Prefabs/boom");
			Instantiate(ResourcesManager.instance.boom,pos+new Vector3(0,0,offset_z),rotat);
		}else{
			StartCoroutine(delay_effect(pos,rotat,delay));
		}
	}
	IEnumerator delay_effect(Vector3 pos,UnityEngine.Quaternion rotat, float delay)
	{
		//		
		yield return new WaitForSeconds(delay);
		//		Debug.Log("WaitForSeconds");
		create_effect(pos,rotat,0);
	}


	public void create_level_end_scoreflash()
	{
		int random = Random.Range(1,4);
		string str="" ;
		switch(random)
		{
		case 1: str ="Nice!"; break;
		case 2:str ="Good!"; break;
		case 3: str ="Awesome!"; break;
		case 4:str ="Cool!"; break;
		}
		ScoreFlash.Push(str);
	}


}
