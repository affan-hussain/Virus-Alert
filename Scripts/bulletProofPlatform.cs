using UnityEngine;
using System.Collections;

public class bulletProofPlatform : MonoBehaviour {

	void onTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "Dangerous")
						Destroy (coll.gameObject);
	}
}
