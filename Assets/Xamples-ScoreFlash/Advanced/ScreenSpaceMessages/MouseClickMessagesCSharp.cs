/****************************************************
 *  (c) 2012 narayana games UG (haftungsbeschränkt) *
 *  This is just an example, do with it whatever    *
 *  you like ;-)                                    *
 ****************************************************/

using UnityEngine;
using System.Collections;

public class MouseClickMessagesCSharp : MonoBehaviour {

    public bool randomColors = false;

	void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            string text = string.Format("({0:000}, {1:000})", screenPosition.x, screenPosition.y);

            if (randomColors) {
                Color color = new Color(
                    Random.Range(0.3F, 1.0F), // r
                    Random.Range(0.3F, 1.0F), // g
                    Random.Range(0.3F, 1.0F), // b
                    1.0F // alpha is controlled via alpha multiplier (under Colors on the prefab)
                    );

                ScoreFlash.Instance.PushScreen(screenPosition, text, color);
            } else {
                ScoreFlash.Instance.PushScreen(screenPosition, text);
            }

        }
	}
}
