using UnityEngine;
using System.Collections;

public class enemyShoot : MonoBehaviour {

	public float fireRate = 0;
	public LayerMask ToHit;
	
	public Transform BulletTrailPrefab;
	
	float timeToSpawnBullet = 0;
	public float bulletRate = 20;
	float timeToFire = 0;
	Transform firePoint;
	public Transform checkR;

	// Use this for initialization
	void Awake () {
		
		firePoint = transform.FindChild ("gunHole");
		if (firePoint == null) {
			Debug.LogError("there is no firePoint");
		}

	}
	
	// Update is called once per frame
	void Update () {
			if(Time.time > timeToFire){
				timeToFire = Time.time + 1/fireRate;
				shoot();
			}

		var dirL = checkR.transform.position - transform.position;
		var angleL = Mathf.Atan2(dirL.y, dirL.x) * Mathf.Rad2Deg;
		firePoint.rotation = Quaternion.AngleAxis(angleL, Vector3.forward);
	}
	
	void shoot(){
		Vector2 checkPosition = new Vector2 (checkR.transform.position.x,checkR.transform.position.y);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x,firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, checkPosition-firePointPosition,100,ToHit);
	

		if (Time.time >= timeToSpawnBullet) {
			
			bullet ();	
			timeToSpawnBullet = Time.time + 1/bulletRate;
		}

		
	}
	
	void bullet(){
			Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation);

	}
}
