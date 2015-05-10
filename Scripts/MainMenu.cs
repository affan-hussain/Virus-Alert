using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {

	public InputField name;          //let the player enter his name

	void Awake(){
		
		Screen.SetResolution (1280,720,false,30);
		//if there is no where to enter a name return a warning
		if (name == null)
						Debug.LogWarning ("no Input Field");
	}

	public void quitGame(){ 
		Debug.Log ("The game exited"); // send a message to console to know the game quit
		Application.Quit (); // this method quits the game
	}

	public void startGame(){ //this method is tied to the play button it goes to the title screen
		Application.LoadLevel ("confirmPlay"); // the method that actually loads the "your system has been been infected.."
	}

	public void startInstructions2(){//this method is tied to the yes button
		Application.LoadLevel ("instruction2"); // this method loads the instructions screen before level 1
	}

	public void startInstructions (){
		Application.LoadLevel ("instruction"); //load instructions from main screen
	}

	public void credits(){
		Application.LoadLevel ("credits"); // load the credits
	}

	public void goToMain(){
		Application.LoadLevel ("mainMenu"); // load the main menu
	}

	public void loadLevelOne(){
	
		PlayerPrefs.SetString ("playerName", name.text); // set the player name
		PlayerPrefs.SetInt ("bonus", 0); //resets bonus for new game
		Application.LoadLevel ("level1"); //load level 1
	}

	public void loadLevelTwo(){
		Application.LoadLevel ("level2"); // load level 2
	}

	public void loadLevelThree(){
		Application.LoadLevel ("level3"); // load level 3
	}

	public void loadLevelFour(){
		Application.LoadLevel ("level14"); // load level 4
	}

	public void loadLevelFive(){
		Application.LoadLevel ("level5"); // load level 5
	}

	public void loadQuit(){
		Application.LoadLevel ("confirm"); // load the confirm quit
	}

	public void loadHighscores(){
		Application.LoadLevel ("highScores");// load the high scores
	}
}
