using UnityEngine;
using System.Collections;

public class weopon : MonoBehaviour {

	public float bulletRate = 20;                   //how fast the bullets come out of the gun
	public float fireRate = 0;						//rate at which the player can shoot
	public LayerMask ToHit;                         //things that the bullets can hit
	public Transform BulletTrailPrefab;             // the bullet prefab

	float timeToSpawnBullet = 0;                   
	float timeToFire = 0;         					
	Transform firePoint;							//where the bullets come out

	// Use this for initialization
	void Awake () {

		//find the gun hole and if not found give an error message
		firePoint = transform.FindChild ("gunHole");

		if (firePoint == null) {
			Debug.LogError("there is no firePoint");
		}

		if (PlayerPrefs.GetInt ("firstScore") > 4470) {
			fireRate = 6;
		
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if single shot weopon then only shoot when left mouse button is clicked
		if (fireRate == 0) {
			if(Input.GetButtonDown("Fire1")){
				shoot();
			}
		}

		//otherwise if rapid fire weopon check if its time to fire and if it is then shoot
		else{
			if(Input.GetButton("Fire1") && Time.time > timeToFire){
				timeToFire = Time.time + 1/fireRate;
				shoot();
			}
			
		}
	}

	void shoot(){
		//gets the mouse position as a vector 2
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		//gets the position of the gun
		Vector2 firePointPosition = new Vector2 (firePoint.position.x,firePoint.position.y);
		//cast a ray from the gun to the mouse
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition,100,ToHit);


		//if its time to spawn a bullet then spawn a bullet
		if (Time.time >= timeToSpawnBullet) {
			bullet ();	
			timeToSpawnBullet = Time.time + 1/bulletRate;
		}


	}

	void bullet(){
		//create a bullet
		Instantiate (BulletTrailPrefab,firePoint.position, firePoint.rotation);

	}

}
