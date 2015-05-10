using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class bossScript : MonoBehaviour {

	public float shotsToKill = 3;							//	shots needed to kill the boss
	public Slider bossSlider;								//	the bosses health bar
	public Player player;									//	reference to the player object
	public GameObject panel;								//	the question panel

	private Animator question;								// the question panel animator
	private Animator bossAnim;								// the boss animator
	private followPath bossPath;							// the path the boss follows
	private float health = 1000;							// the health the boss has
	private float bulletDamage;								// the damage each bullet does to the boss
	private bool beginBattle = false;						// has the battle begun
	private bool questionCorrect;							// did you get the question correct

	void Start(){
		bossAnim = GetComponent<Animator> ();				// get the animator on the boss
		question = panel.GetComponent<Animator>();			// get the animator on the question panel
		bulletDamage = health / shotsToKill;				// set the bullet damage 
		bossPath = GetComponent<followPath>();				// find the path the boss needs to follow
		bossPath.enabled = false;							// disble the path follow
		bossAnim.enabled = false;							// disable the boss animator
		question.enabled = false;							// disable the question animator
	}
	
	void Update(){

		bossSlider.value = health;							// set the health bar equal to the boss' health
		bossAnim.Play ("moveBackAndForth");					// play the move back and forth animation of the boss
		//while the question isn't correctly answered
		if (!questionCorrect) {
			//check if the boss is less than half health
			if (health <= 500) {
				question.enabled = true;   					// if he is then enable the question animatro
				question.Play ("QuestionSlideIn"); 			// and play the question slide in
				Time.timeScale = 0;							// and pause the scene
		
			}
		}
		 //if the boss is dead
		if (health <= 0) {
			//save the score
			player.pStats.saveCurrentScore("Level5", player.pStats.point());
			//load the next level
			Application.LoadLevel("yourScore");
			//destroy the boss
			Destroy (this.gameObject);
		}
	}

	//used to start the boss battle
	public void startBoss(){

		beginBattle = true;									// set beginBattle to true
		bossPath.enabled = true;							// enable the boss path
		bossAnim.enabled = true;							// enable the boss animator

	}
	
	void OnCollisionEnter2D(Collision2D coll){
		//if hit by a bullet then take bulletDamage
		if (coll.gameObject.tag == "bullet") {
				health -= bulletDamage;
		}
	}
	//if the question is correct then
	public void correctAnswer(){
		//slide out the panel
		question.Play ("QuestionSlideOutAnim");
		//set question correct to true
		questionCorrect = true;
		//unpause the scene
		Time.timeScale = 1;
	}
	//if the question is wrong
	public void wrongAnswer(){
		//bring the boss back to full health
		health = 1000;
		//slide out the question
		question.Play ("QuestionSlideOutAnim");
		//unpause the scene
		Time.timeScale = 1;
	}



}
