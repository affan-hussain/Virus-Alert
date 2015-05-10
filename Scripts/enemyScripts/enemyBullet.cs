using UnityEngine;
using System.Collections;

public class enemyBullet : MonoBehaviour {


	//if the bullet hits the player or gets hit by the player bullet then destroy the bullet
	void OnCollisionEnter2D(Collision2D coll) {

				if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "bullet" || coll.gameObject.tag == "platform") {
						Destroy (this.gameObject);
				}
		}
}
