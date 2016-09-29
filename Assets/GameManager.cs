using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	static int playerScore = 0;

	public GUISkin theSkin;

	void UpScore(int amount){
		playerScore += amount;
	}

	void OnGUI(){
		GUI.skin = theSkin;
		GUI.Label (new Rect(Screen.width-300, 20, 1000, 100), "" + playerScore);
	}
}
