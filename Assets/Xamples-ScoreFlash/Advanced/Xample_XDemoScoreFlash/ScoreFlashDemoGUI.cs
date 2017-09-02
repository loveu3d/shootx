/****************************************************
 *  (c) 2012 narayana games UG (haftungsbeschränkt) *
 *  This is just an example, do with it whatever    *
 *  you like ;-)                                    *
 ****************************************************/

using UnityEngine;
using System.Collections;
using NarayanaGames.Common.UI;

/// <summary>
///     This is some real spaghetti code hacked together quickly.
/// </summary>
public class ScoreFlashDemoGUI : MonoBehaviour {

    public bool includeBackgroundColors = true;

    #region Simple FPS counter
    // FPS-Counter based on Wiki: http://wiki.unity3d.com/index.php?title=FramesPerSecond
    private float updateInterval = 0.5F;
    private float accum = 0; // FPS accumulated over the interval
    private int frames = 0; // Frames drawn over the interval
    private float timeleft; // Left time for current interval

    private string currentFPS = "";

    public GUISkin[] skins;
    public string[] skinNames;

    void Start() {
        timeleft = updateInterval;
        Application.targetFrameRate = 200;
	}
	
	void Update() {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        if (timeleft <= 0.0) {
            float fps = accum / frames;
            string format = System.String.Format("{0:F2}", fps);
            currentFPS = format;

            timeleft = updateInterval;
            accum = 0.0F;
            frames = 0;
        }
    }
    #endregion Simple FPS counter

    public void OnGUI() {
        GUI.depth = 1000;

        // show current frames per seconds for convenience
        Rect rect = new Rect(Screen.width - 50F, Screen.height - 30F, 40F, 25F);
        GUI.Label(rect, currentFPS);

        rect.x = 10F;
        rect.y = 10F;

        rect.width = 200F;
        float y = rect.y;
        /*
         * scoreFlashInstance returns an IScoreFlash with what's really needed ...
         * we use a whole lot of stuff that's not really meant to be used from
         * scripting here, so we need to cast this to ScoreFlash which is the
         * full MonoBehaviour and has everything available to mess with ;-)
         */
        ScoreFlash scoreFlashInstance = ((ScoreFlash)ScoreFlash.Instance);

        scoreFlashInstance.isTestAutogenerateMessages = GUI.Toggle(rect, scoreFlashInstance.isTestAutogenerateMessages, "Auto generate messages?");

        rect.y += 20F;
        bool includeVeryLongMessages = GUI.Toggle(rect, scoreFlashInstance.includeVeryLongMessages, "Include very long messages?");
        if (includeVeryLongMessages && !scoreFlashInstance.includeVeryLongMessages) {
            scoreFlashInstance.skin = skins[4];
            ScoreFlash.Push("These work best with Vanilla Small ...");
            scoreFlashInstance.skin = skins[3];
            ScoreFlash.Push("... or Vanilla!");
        }
        scoreFlashInstance.includeVeryLongMessages = includeVeryLongMessages;

        rect.y = y;
        rect.x += rect.width;
        GUI.Label(rect, "Skins");
        for (int i = 0; i < skins.Length; i++) {
            rect.y += 20F;
            if (GUI.Toggle(rect, skins[i] == scoreFlashInstance.skin, skinNames[i])) {
                scoreFlashInstance.skin = skins[i];
            }
        }


        float x = 10F;
        rect.x = x;
        rect.y = y + 40F;
        scoreFlashInstance.fadeInTimeSeconds = Slider(ref rect, "Fade In", scoreFlashInstance.fadeInTimeSeconds, 0.1F, 10F);
        rect.x = x;
        rect.y += 20F;
        scoreFlashInstance.readTimeSeconds = Slider(ref rect, "Read Time", scoreFlashInstance.readTimeSeconds, 0.1F, 10F);
        rect.x = x;
        rect.y += 20F;
        scoreFlashInstance.fadeOutTimeSeconds = Slider(ref rect, "Fade Out", scoreFlashInstance.fadeOutTimeSeconds, 0.1F, 10F);


        rect.x = 10F;
        rect.y += 30F;
        y = rect.y;
        if (includeBackgroundColors) {
            Camera.main.backgroundColor = DrawColorSelection(ref rect, "Background Colors", Camera.main.backgroundColor);
            rect.y = y;
            rect.x += rect.width + 30F;
        }

        scoreFlashInstance.fadeInColor = DrawColorSelection(ref rect, "Initial", scoreFlashInstance.fadeInColor);

        if (!includeBackgroundColors) { // we have some space to control the outline :-)
            rect.y -= 30F;
            rect.x += rect.width + 30F;
            scoreFlashInstance.disableOutlines = GUI.Toggle(rect, scoreFlashInstance.disableOutlines, "Disable outlines?");
            rect.y += 30F;
        }


        rect.x = 10F;
        rect.y += 30F;
        y = rect.y;
        scoreFlashInstance.readColorStart = DrawColorSelection(ref rect, "Read Start", scoreFlashInstance.readColorStart);

        rect.x += rect.width + 30F;
        rect.y = y;
        scoreFlashInstance.readColorEnd = DrawColorSelection(ref rect, "Read End", scoreFlashInstance.readColorEnd);

        rect.x = 10F;
        rect.y += 30F;
        y = rect.y;
        scoreFlashInstance.fadeOutColor = DrawColorSelection(ref rect, "Fade Out", scoreFlashInstance.fadeOutColor);

        rect.x += rect.width + 30F;
        rect.width = 200F;

        rect.y = y;
        GUI.Label(rect, "Screen Alignment");
        rect.y += 20F;

        rect.width = 80F;
        if (GUI.Toggle(rect, scoreFlashInstance.screenAlign == NGAlignment.ScreenAlign.TopCenter, "Top")) {
            scoreFlashInstance.screenAlign = NGAlignment.ScreenAlign.TopCenter;
        }

        rect.y += 25F;
        if (GUI.Toggle(rect, scoreFlashInstance.screenAlign == NGAlignment.ScreenAlign.MiddleCenter, "Middle")) {
            scoreFlashInstance.screenAlign = NGAlignment.ScreenAlign.MiddleCenter;
        }

        rect.y += 25F;
        if (GUI.Toggle(rect, scoreFlashInstance.screenAlign == NGAlignment.ScreenAlign.BottomCenter, "Bottom")) {
            scoreFlashInstance.screenAlign = NGAlignment.ScreenAlign.BottomCenter;
        }

        rect.x = 10F;
        rect.y = Screen.height - 30;
        rect.width = Screen.width - rect.x * 2;
        GUI.Label(rect, "This is just a small subset of the possible configuration settings - for more, see documentation / demo video!");
    }

    private float Slider(ref Rect rect, string label, float inValue, float min, float max) {
        rect.width = 100F;
        GUI.Label(rect, label);
        rect.x += 150F;
        GUI.Label(rect, string.Format("{0:0.0}s", inValue));
        rect.x -= 80F;
        rect.width = 75F;
        rect.y += 4F;
        inValue = GUI.HorizontalSlider(rect, inValue, min, max);
        rect.y -= 4F;
        return inValue;
    }

    private Color DrawColorSelection(ref Rect rect, string label, Color result) {
        rect.width = 100F;
        rect.height = 20F;
        GUI.Label(rect, label);

        rect.y += rect.height + 10F;
        rect.width = 100F;
        rect.height = 10F;
        Color color = GUI.color;
        
        GUI.color = Color.red;
        result.r = GUI.HorizontalSlider(rect, result.r, 0F, 1F);

        GUI.color = Color.green;
        rect.y += rect.height + 5F;
        result.g = GUI.HorizontalSlider(rect, result.g, 0F, 1F);

        GUI.color = Color.blue;
        rect.y += rect.height + 5F;
        result.b = GUI.HorizontalSlider(rect, result.b, 0F, 1F);

        GUI.color = color;
        rect.y += rect.height + 5F;
        result.a = GUI.HorizontalSlider(rect, result.a, 0F, 1F);
        rect.height = 25F;

        return result;
    }
}
