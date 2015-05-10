using UnityEngine;
using System.Collections;

public class scoreScreen : MonoBehaviour {

	public GUIText score;      // shows the score
	public GUIText name;	   // shows the name
	public GUIText bon;		   // shows the bonus
	private int points;        // total point
	// Use this for initialization
	void Start () {

		int Level1 = PlayerPrefs.GetInt ("Level1"); // get the level 1 score
		int Level2 = PlayerPrefs.GetInt ("Level2"); // get the level 2 score
		int Level3 = PlayerPrefs.GetInt ("Level3"); // get the level 3 score
		int Level4 = PlayerPrefs.GetInt ("Level4"); // get the level 4 score
		int Level5 = PlayerPrefs.GetInt ("Level5"); // get the level 5 score
		int bonus = PlayerPrefs.GetInt ("bonus");
		int enemies = bonus / 10;

		points = Level1 + Level2 + Level3 + Level4 + Level5 + bonus; // add up all the scores

		name.guiText.text = PlayerPrefs.GetString ("playerName"); //display name
		PlayerPrefs.SetInt ("lastScore" , points); //save the score
		score.guiText.text = points.ToString (); //display the score
		bon.guiText.text = "You killed " + enemies.ToString() + " enemies for a total of " + bonus.ToString() + " bonus points";


	}
}
