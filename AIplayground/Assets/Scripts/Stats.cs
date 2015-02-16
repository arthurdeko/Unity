using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stats : MonoBehaviour {
	
	public Canvas hud;
	private float score = 0;

	public float updateScore() {
		Text scoreDisplay = hud.GetComponent<Text> ();
		scoreDisplay.text = "test";
		return 1f;
	}

	
}
