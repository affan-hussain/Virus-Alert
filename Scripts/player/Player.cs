using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {



	public Slider healthBarSlider;  		// reference for slider
	public int offTheScreen = -10;          // kill the player if he falls through
	public int damageRate;                  // the rate at which the player takes damage from enemies
	public AudioClip coinSound;				// the sound to play when picking up a coin
	public AudioClip hitSound;				// the sound to play when hit by an enemy
	public AudioClip bulletSound;				// the sound to play when hit by an enemy bullet
	public GUIText score;					// the text used for score

	private string levelName;				// the name of the current level





	// this class is used for holding all the stats the player has
	// its best to keep this in a seperate class because it resets every level
	public class playerStats{

		private int points = 0;        		 // the points the player has accumulated
		public float health = 100; 			 // the players health

		//subtract damage from players health
		public void takeDamage(float damage){
			health -= damage;
		}

		//return the remaining health 
		public float hp(){
			return health;
		}

		//add points the player's point
		public void addPoints(int amount){

			points += amount;
		}

		//return the points the player has earned
		public int point(){

			return points;
		}

		//save the points the player has earned for use later
		public void saveCurrentScore(string Level, int score){

			PlayerPrefs.SetInt (Level, score );
		}
	}



	public playerStats pStats = new playerStats ();

	void Start(){
		 levelName = Application.loadedLevelName;              //set the level name to the current level name
	}





	void Update(){

		//if off the screen kill the player
		if (transform.position.y <= offTheScreen)
			pStats.takeDamage (200f);


		//if the player dies restart the level
		if (pStats.hp () <= 0) 
			Application.LoadLevel(levelName);
		

		healthBarSlider.value = pStats.hp ();					// set the health bar to the current hp
		score.guiText.text = "Score:" + pStats.point ();		// show the players score


	}





	void OnCollisionStay2D(Collision2D coll) {
		//if the player is touching the enemy take damage at the rate of damageRate
		if (coll.gameObject.tag == "Enemy") {
			pStats.takeDamage(damageRate);

		}

		//if the player is touching the boss take damage at the rate of .5 health
		if (coll.gameObject.tag == "boss") {
			pStats.takeDamage(.5f);
		}


	}

	void OnCollisionEnter2D(Collision2D coll){

		//if hit by an enemy bullet take 10 damage
		if (coll.gameObject.tag == "Dangerous") {
						pStats.takeDamage (10f);
						
		}
		if(coll.gameObject.tag == "Enemy")
			audio.PlayOneShot(hitSound);
		//when the end of level is reached
		if (coll.gameObject.tag == "Finish") {

			int score = pStats.point();							 // an int with the player score
			pStats.saveCurrentScore(levelName , score);			 // save the current score with the key of the current levels name
			
		}

	


	}
		
	void OnTriggerEnter2D(Collider2D coll) {

		//when a coin is collected add points to the players score
		//send a message to the console
		//destroy the coin 
		//and play the coin sound
		// this is applied to all 3 types of coins
		
		if (coll.gameObject.tag == "Bronze Coin") {
			pStats.addPoints(10);
			Debug.Log("Picked up bronze coin");
			Destroy(coll.gameObject);
			audio.PlayOneShot(coinSound);
		}

		if (coll.gameObject.tag == "Gold Coin") {
			pStats.addPoints(100);
			Debug.Log("Picked up gold coin");
			Destroy(coll.gameObject);
			audio.PlayOneShot(coinSound);
		}
		
		if (coll.gameObject.tag == "Silver Coin") {
			pStats.addPoints(20);
			Debug.Log("Picked up silver coin");
			Destroy(coll.gameObject);
			audio.PlayOneShot(coinSound);
		}

		//if hit by an enemy bullet take 10 damage
		if (coll.gameObject.tag == "Dangerous") {
			audio.PlayOneShot(bulletSound);
						pStats.takeDamage (10f);
			Destroy(coll.gameObject);
				}
	
	}
}
