using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class answerRandomizer : MonoBehaviour {

	// game objects of buttons
	public GameObject choice1;				
	public GameObject choice2;				
	public GameObject choice3;
	public GameObject choice4;

	// answer texts
	string text1;
	string text2;
	string text3;
	string text4;



	// Use this for initialization
	void Start () {

		GameObject[] answerSpots = {choice1, choice2, choice3, choice4};

		//set texts to answer texts
		text1 = choice1.GetComponentInChildren<Text>().text;
		text2 = choice2.GetComponentInChildren<Text>().text;
		text3 = choice3.GetComponentInChildren<Text>().text;
		text4 = choice4.GetComponentInChildren<Text>().text;

		string[] answers = {text1, text2, text3, text4};

		//shuffle the text array
		for (int i = 0; i < answers.Length; i++) {
			string temp = answers[i];
			int randomString = Random.Range(0,answers.Length);
			answers[i] = answers[randomString];
			answers[randomString] = temp;
		}

		for (int i = 0; i < answerSpots.Length; i++) {
					
			answerSpots[i].GetComponentInChildren<Text>().text = answers[i];
		
		}
	}
}
