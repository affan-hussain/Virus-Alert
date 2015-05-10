using UnityEngine;
using System.Collections;

public class goblin : MonoBehaviour {




	//this script is the basis of the bat script 
	//the code is the same but it  originally had extra functions which 
	//were found to not be nesseccary later

	public int shotsToKill;											// number of shots needed to kill the enemy
	private int health = 100;										// the enemies health
	private int bulletDamage;										// the damage on bullet does
	
	void Start(){
		bulletDamage = health / shotsToKill;						//set the bullet damage
	}	
	
	// Update is called once per frame
	void Update () {
		
		//if the enemy has no health left destroy it and send a message to the console
		if (health <= 0) {
			int x  = PlayerPrefs.GetInt("bonus");
			PlayerPrefs.SetInt("bonus",x + 10);
			Destroy (this.gameObject);
			Debug.Log ("enemy is dead");

			
		}
	}
	void OnCollisionEnter2D(Collision2D coll) {

		//when hit by a player bullet lose health equal to bulet damage then destroy the bullet
		if (coll.gameObject.tag == "bullet") {
			health -= bulletDamage;
			Destroy(coll.gameObject);
		}
	}


}
