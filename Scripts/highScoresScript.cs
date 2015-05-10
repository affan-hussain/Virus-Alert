using UnityEngine;
using System.Collections;

public class highScoresScript : MonoBehaviour {


	public GUIText first; //first highest score
	public GUIText second; // second highest score
	public GUIText third; //third highest score
	public GUIText fourth; //fourth highest score
	public GUIText fifth; // fifth highest score

	// Use this for initialization
	void Start () {

		//get the top 5 scores and the last earned score
		int firstScore = PlayerPrefs.GetInt("firstScore");
		int secondScore = PlayerPrefs.GetInt("secondScore");
		int thirdScore = PlayerPrefs.GetInt("thirdScore");
		int fourthScore = PlayerPrefs.GetInt("fourthScore");
		int fifthScore = PlayerPrefs.GetInt("fifthScore");
		int lastScore = PlayerPrefs.GetInt("lastScore");

		//make an array of those scores
		int[] scores = new int[] {firstScore, secondScore, thirdScore, fourthScore, fifthScore, lastScore};

		//sort the array in descending order
		for (int i = 0; i < scores.Length; i++)
		{
			for (int j = i+1; j < scores.Length; j++)
			{
				if (scores[i] < scores[j])
				{
					scores[i] = scores[i] + scores[j];
					scores[j] = scores[i] - scores[j];
					scores[i] = scores[i] - scores[j];
				}
			}
		}

		//save the new scores 
		PlayerPrefs.SetInt("firstScore", scores[0]);
		PlayerPrefs.SetInt("secondScore", scores[1]);
		PlayerPrefs.SetInt("thirdScore", scores[2]);
		PlayerPrefs.SetInt("fourthScore", scores[3]);
		PlayerPrefs.SetInt("fifthScore", scores[4]);
		PlayerPrefs.SetInt("lastScore", 0);
		//set the guiTexts to the scores
		first.text = "1. " + scores [0].ToString ();
		second.text = "2. " + scores [1].ToString ();
		third.text = "3. " +  scores [2].ToString ();
		fourth.text = "4. " +  scores [3].ToString ();
		fifth.text = "5. " +  scores [4].ToString ();




	}

}
