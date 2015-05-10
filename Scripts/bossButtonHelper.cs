using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class bossButtonHelper : MonoBehaviour {

	public GameObject boss;

	public void checkAnswer ()
	{
		
		bool correct = false;
		string currentLevel = Application.loadedLevelName;
		
		String answer5 = "Ethernet is the standard way to connect computers on a network over a wired connection.";
		String answerThing = gameObject.GetComponentInChildren<Text> ().text;
		
		String p5 = answer5.Substring(70,5);
		
		String answerText = "";
		
		Debug.LogError (p5);
		
		
		
		
		if (answerThing.Length < 70)
			answerText = "";
		else
			answerText = answerThing.Substring (70, 5);

		
		if (answerText.Equals (p5)) {
			correct = true;
			Debug.LogError ("correct answer");
		}
		
		if (correct) {
			boss.GetComponent<bossScript>().correctAnswer();
		} 
		else {
			boss.GetComponent<bossScript>().wrongAnswer();
		}
	}

}
