using UnityEngine;
using System.Collections;

using NarayanaGames.ScoreFlashComponent;

public class MultiScoreFlashMultiObject : MonoBehaviour {

	public ScoreFlashFollow3D cubeA;
	public ScoreFlashFollow3D cubeB;
	public ScoreFlashFollow3D cubeC;

	void OnGUI() {
		DrawButtons(cubeA, -1);
		DrawButtons(cubeB,  0);
		DrawButtons(cubeC, +1);
	}

	private void DrawButtons(ScoreFlashFollow3D cube, int xPos) {
		Rect rect = new Rect(10F, 10F, 130F, 20F);

		if (xPos < 0) {
			rect.x = 10F;
		} else if (xPos > 0) {
			rect.x = Screen.width - (rect.width + 10F);
		} else {
			rect.x = (Screen.width - rect.width) * 0.5F;
		}

		if (GUI.Button(rect, string.Format("{0} +10", cube.name))) {
			ScoreFlashGreen.PushWorld(cube, "+10");
		}

		rect.y += rect.height + 10F;

		if (GUI.Button(rect, string.Format("{0} -10", cube.name))) {
			ScoreFlashRed.PushWorld(cube, "-10");
		}

		rect.y += rect.height + 10F;

		if (GUI.Button(rect, string.Format("{0} Say Hey!", cube.name))) {
			ScoreFlashSaySomething.PushWorld(cube, "Hey, waddup?");
		}
	}

	private IScoreFlash ScoreFlashGreen {
		get { return ScoreFlashManager.Get("ScoreFlashB-Green"); }
	}

	private IScoreFlash ScoreFlashRed {
		get { return ScoreFlashManager.Get("ScoreFlashA-Red"); }
	}

	private IScoreFlash ScoreFlashSaySomething {
		get { return ScoreFlashManager.Get("ScoreFlashC-White"); }
	}

}
