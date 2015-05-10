using UnityEngine;
using Pathfinding;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]     // require the enemy to have a rigid body
[RequireComponent(typeof(Seeker))]			// require the enemy to have a seeker script attached

public class enemyAI : MonoBehaviour
{

		public Transform target; 			//what to chase
		public float updateRate = 2f;		//how many times each second the path will be updated

		[HideInInspector]
		
	private Seeker seeker;				//refference to the seeker script
	private Rigidbody2D rb;				//refference to the rigidbody of the object	

	public bool pathIsEnded = false;    //has it reached the end of the path
	public Path path;					//the calculated path
	public float speed = 300f;			//The AI's speed per second
	public ForceMode2D fmode; 			//how to apply force
	public float nextWayointDistance;	//the max distance from the AI to a waypoint for it to continue to the next way point
	private int currentWaypoint = 0; 	//the waypoint we are moving towards

		void Start ()
		{

				seeker = GetComponent<Seeker> ();    //find the seeker component
				rb = GetComponent<Rigidbody2D> ();	 //find the rigidbody

				//if there is no target then show an error
				if (target == null) {
						Debug.LogError ("no Player found");
						return;	
				}

				//start a new path to the target position and return the result to the onPathComplete function
				seeker.StartPath (transform.position, target.position, OnPathComplete);

				StartCoroutine (UpdatePath ());

		}

		IEnumerator UpdatePath ()
		{

		//if there is no target return false;
				if (target == null) {

						return false;
		
				}
	
				//start a new path to the target position and return the result to the onPathComplete function
				seeker.StartPath (transform.position, target.position, OnPathComplete);
				//wait for update rate before updating the path
				yield return new WaitForSeconds (1f / updateRate);
				StartCoroutine (UpdatePath ());
		}

		public void OnPathComplete (Path p)
		{
				Debug.Log ("there is a path is there an error; " + p.error);
				
				//if there is no error then set path to p and reset the current way point
				if (!p.error) {
				
						path = p;
						currentWaypoint = 0;
				}

		}

		void FixedUpdate(){
		//if no target then return
		if (target == null) {
			
			return;
			
		}
		//if no path then return
		if (path == null)
						return;
		//if reached the end of path then return
		if (currentWaypoint >= path.vectorPath.Count) {
						if (pathIsEnded)
								return;
			Debug.Log("end of path reached");
			pathIsEnded = true;
			return;


		}
		//if not reached the end of path then set pathIsEnded to false
		pathIsEnded = false;
		//direction to the next waypoint
		Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position).normalized;

		dir *= speed * Time.fixedDeltaTime;


		//move the enemy
		rb.AddForce (dir, fmode);

		//vector 3 of the distance to waypoint
		float dist = Vector3.Distance(transform.position,path.vectorPath[currentWaypoint]);
		/// if the object has reached the way point then move to the next way point
		if (dist < nextWayointDistance) {
				
			currentWaypoint++;
			return;
		
		}

	}




}
