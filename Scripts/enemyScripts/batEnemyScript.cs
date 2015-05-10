using UnityEngine;
using Pathfinding;
using System.Collections;


public class batEnemyScript : MonoBehaviour {

	public float shotsToKill = 3;						//shots to kill the enemy defaulted to 3

	private float health = 1000;						//the enemies health
	private float bulletDamage;							//the damage one player bullet does

	void Start(){

		bulletDamage = health / shotsToKill;			//set the bullet damage
	}

	void Update(){
		//if the enemy has no health then destroy the enemy
		if (health <= 1) {
			int x = PlayerPrefs.GetInt("bonus");
			PlayerPrefs.SetInt("bonus", x + 10);
						Destroy (this.gameObject);
				}
	}



	void OnCollisionEnter2D(Collision2D coll){
		//when hit by a bullet take damage equal to bullet damage
		if (coll.gameObject.tag == "bullet")
						health -= bulletDamage;

	}
}
