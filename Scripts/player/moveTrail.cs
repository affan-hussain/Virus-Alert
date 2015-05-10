using UnityEngine;
using System.Collections;

public class moveTrail : MonoBehaviour {

	public int moveSpeed = 230;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);		//move the bullet with a speed of movespeed
		Destroy (this.gameObject,2);											//destroy the bullet after 2 seconds
	}

	//if for some reason a bullet hits the player then destroy the bullet
	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag != "Player")
			Destroy (this.gameObject);
	}
}
