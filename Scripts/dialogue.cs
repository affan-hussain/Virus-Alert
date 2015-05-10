using UnityEngine;
using System.Collections;

public class dialogue : MonoBehaviour {

	//refrence for the pause menu panel in the hierarchy
	public GameObject pauseMenuPanel;
	//animator reference
	private Animator anim;
	//variable for checking if the game is paused 
	private bool isPaused = false;
	
	
	// Use this for initialization
	void Start () {
		//unpause the game on start
		Time.timeScale = 1;
		//get the animator component
		anim = pauseMenuPanel.GetComponent<Animator>();
		//disable it on start to stop it from playing the default animation
		anim.enabled = false;
	}
	
	
	void OnCollisionEnter2D(Collision2D coll){

		//once player reaches the end enter the question
		if (coll.gameObject.tag == "Player") {
			enterQuestion ();
		}
	}
	
	//function to bring in question
	public void enterQuestion(){
		//enable the animator component
		anim.enabled = true;
		//play the Slidein animation
		anim.Play("DialogueIn");
		//freeze the timescale
		Time.timeScale = 0;
	}

	public void exitQuestion(){

		//play the Slidein animation
		anim.Play("DialogueOut");
		//freeze the timescale
		Time.timeScale = 1;

		//enable the animator component
		anim.enabled = true;

		Destroy (this.gameObject);

	}

}
