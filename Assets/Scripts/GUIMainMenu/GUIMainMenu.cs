using UnityEngine;
using System.Collections;

public class GUIMainMenu : MonoBehaviour {

	public GUITexture startButton;
	public GUITexture hiScoreButton;
	public GUITexture optionsButton;
	public GUITexture exitButton;

	void Update() {
		if(startButton.HitTest(Input.GetTouch(0).position)) {
			Application.LoadLevel(1);
		} else if (exitButton.HitTest(Input.GetTouch(0).position)) {
			Application.Quit();
		}

	}


}
