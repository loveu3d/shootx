using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ScoreFlashLayout))]
public class Xample_TestLayout : MonoBehaviour {

	public string label = "Label:";

	private ScoreFlashLayout layout = null;

	void Awake() {
		layout = GetComponent<ScoreFlashLayout>();
	}

	void Start() {
	    // NOTE: When this is done in start,
	    // it may not work with forced Retina; to
	    // make it work with forced Retina, add a
	    // tiny delay (using a Coroutine)!
		layout.Push(label);
	}


}
