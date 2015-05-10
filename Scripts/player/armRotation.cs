using UnityEngine;
using System.Collections;

public class armRotation : MonoBehaviour {

	public int offSet = 0; // incase the arm rotation needs tuning

	// Update is called once per frame
	void Update () {
		//subtracting player position and mouse
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position; 
		difference.Normalize ();  //normailze vector meaning the sum of the vector is equal to 1

		//find the angle needed then convert it from radians to degree
		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler (0f, 0f, rotZ + offSet); // set the arm to the right angle



	}
}
