using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class buttonHelper : MonoBehaviour
{

public void checkAnswer ()
{

		bool correct = false;
		string currentLevel = Application.loadedLevelName;

		String answer2 = "The Internet is a global system of interconnected computer networks"; //(18,7)
		String answer1 = "Networking is linking two or more computing devices together to share data";//(64,5)
		String answer3 = "A firewall is a network device or software used for controlling network security";//()
		String answer4 = "An Internet Protocol address (IP address) is a numerical label assigned to each device participating in a computer network.";//()

		String answerThing = gameObject.GetComponentInChildren<Text> ().text;



		String p1 = answer1.Substring (64, 5);
		String p2 = answer2.Substring(18,7);
		String p3 = answer3.Substring(34,8);
		String p4 = answer4.Substring(30,5);

		String answerText = "";

		Debug.LogError (p4);



		if (currentLevel == "Level1") {
			if (answerThing.Length < 63)
				answerText = "";
			else
				answerText = answerThing.Substring (64, 5);
		} 

		else if (currentLevel == "Level2") {
			if (answerThing.Length < 17)
				answerText = "";
			else
				answerText = answerThing.Substring (18, 7);
		} 
		else if (currentLevel == "Level3") {
			if (answerThing.Length < 33)
				answerText = "";
			else
				answerText = answerThing.Substring (34, 8);
		} 
		else if (currentLevel == "Level4") {
			if (answerThing.Length < 20)
				answerText = "";
			else
				answerText = answerThing.Substring (30, 5);
		}


		Debug.LogError (answerText);

		if (answerText.Equals (p1))
						Debug.LogError ("answerText is  " + answerText + "  " + "p1 is  " + p1 + " they are equal" );



		if (answerText.Equals (p1) || answerText.Equals (p2) || answerText.Equals (p3) || answerText.Equals (p4)) {
				correct = true;
				Debug.LogError ("correct answer");
		}
		int x = PlayerPrefs.GetInt("bonus");
		if (correct) {
			PlayerPrefs.SetInt("bonus", x + PlayerPrefs.GetInt("currentBonus"));
				if (currentLevel == "Level1")
						Application.LoadLevel ("level2");
				else if (currentLevel == "Level2")
						Application.LoadLevel ("Level3");
				else if (currentLevel == "Level3")
						Application.LoadLevel ("Level4");
				else if (currentLevel == "Level4")
						Application.LoadLevel ("Level5");
		} else {
				Application.LoadLevel (currentLevel);
			PlayerPrefs.SetInt("currentBonus",0);
		}
}
}
