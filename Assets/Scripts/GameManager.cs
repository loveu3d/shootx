using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static int game_id;

	SpritesManager spritesManager;

	UIManager uiManager;

	void Start () {
		game_id=1;
		spritesManager = this.gameObject.GetComponent<SpritesManager>();
		uiManager = this.gameObject.GetComponent<UIManager>();
	}

	void Update () {	}

	public void EnterNextGame()
	{
		if(game_id==1)
		{
			game_id=2;
		}else{
			game_id=1;
		}

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
