using UnityEngine;
using System.Collections;

public class PlayerCrosshair : MonoBehaviour {

public Texture2D CrosshairSprite;
public bool CrosshairEnabled = true;

	private void Update () {
		if (Input.GetKeyDown (KeyCode.F9)) {
			CrosshairEnabled=!CrosshairEnabled;
				}
		}

	private void OnGUI () {
		if (CrosshairEnabled) {
				GUI.DrawTexture (new Rect ((Screen.width - 50) / 2, (Screen.height - 50) / 2, 50, 50), CrosshairSprite);
		}

	}
}





















