using UnityEngine;
using System.Collections;

public class XAwesome : MonoBehaviour {

	void Start() {
        StartCoroutine(GiveThemAwesome());
	}

    private IEnumerator GiveThemAwesome() {
        while (true) {
            yield return new WaitForSeconds(5F);
            ScoreFlash.Push("You just did something awesome!");
            yield return new WaitForSeconds(3F);
            ScoreFlash.Push("You just did something awesome!");
            yield return new WaitForSeconds(2F);
            ScoreFlash.Push("You really did something awesome!");
            yield return new WaitForSeconds(1F);
            ScoreFlash.Push("You honestly did something awesome!");
            yield return new WaitForSeconds(1F);
            ScoreFlash.Push("You absolutely did something awesome!");
            yield return new WaitForSeconds(1F);
            ScoreFlash.Push("You are awesome!");
            yield return new WaitForSeconds(1F);
            ScoreFlash.Push("You are awesome!");
            yield return new WaitForSeconds(0.5F);
            ScoreFlash.Push("You are awesome!");
            yield return new WaitForSeconds(0.1F);
            ScoreFlash.Push("Awesome!");
            yield return new WaitForSeconds(0.1F);
            ScoreFlash.Push("Awesome!");
            yield return new WaitForSeconds(0.1F);
            ScoreFlash.Push("Awesome!");
            yield return new WaitForSeconds(0.1F);
            ScoreFlash.Push("Awesome!");
            yield return new WaitForSeconds(0.1F);
            ScoreFlash.Push("Awesome!");
            yield return new WaitForSeconds(0.1F);
            ScoreFlash.Push("Awesome!");
            yield return new WaitForSeconds(0.1F);
            ScoreFlash.Push("Awesome!");
            yield return new WaitForSeconds(0.1F);
            ScoreFlash.Push("Awesome!");
            yield return new WaitForSeconds(0.1F);
            ScoreFlash.Push("Awesome!");
            yield return new WaitForSeconds(0.1F);
            ScoreFlash.Push("Awesome!");
            yield return new WaitForSeconds(0.1F);
            ScoreFlash.Push("Awesome!");
            yield return new WaitForSeconds(0.1F);
            ScoreFlash.Push("Awesome!");
        }
    }
}
