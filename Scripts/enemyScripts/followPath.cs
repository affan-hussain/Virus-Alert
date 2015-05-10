using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class followPath : MonoBehaviour
{


		// enum containing the types of ways that movement can be done
		public enum FollowType
		{
				MoveTowards,
				Lerp
		}

		
		public FollowType Type = FollowType.MoveTowards;			// set the follow type to move towards by deafult
		public pathDefinition Path;									// the path to follow
		public float Speed = 1;										// the speed at which to follow the path
		public float MaxDistanceToGoal = .1f;						// how close the object needs to be to reach the point
		private IEnumerator<Transform> _currentPoint;				// the current point to move to


		public void Start ()
		{
				// if there is no path then give an error
				if (Path == null) {
						Debug.LogError ("Path cannot be null", gameObject);
						return;
				}
				
				
				_currentPoint = Path.GetPathsEnumerator (); 		// get the current point from the path 
				_currentPoint.MoveNext ();							// continue to the next point

				//if there are no points dont do anything
				if (_currentPoint.Current == null)
						return;
		
				transform.position = _currentPoint.Current.position; // the object starts at the first point
				

		}
	
		public void Update ()
		{
				// if there are no points then dont do anything
				if (_currentPoint == null || _currentPoint.Current == null)
						return;
				// if using move towards the use built in move towards function to move towards the next point
				if (Type == FollowType.MoveTowards)
						transform.position = Vector3.MoveTowards (transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);
				//otherwise if using lerp the use lerp to move to the next point
				else if (Type == FollowType.Lerp)
						transform.position = Vector3.Lerp (transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);

				//distance from the object to the point
				var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
				
				// if the point has been reached
				if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal) {
			_currentPoint.MoveNext ();								// cycle to the next point		
																	
			Vector3 theScale = transform.localScale;				// the local scale of the object
			theScale.x *= -1;										// flip the local scale
			transform.localScale = theScale;						// apply the flip to the object

			var shot = gameObject.GetComponent<enemyShoot>();       // get the shooting component if the object has one

			//if there is a shooting component
			if(shot != null){

				Transform firePoint;                                // where the enemy shoots from
				firePoint = gameObject.transform.FindChild("gunHole");//find where the enemy shoots from

				//flip the fire point
				Vector3 scale = firePoint.localScale;        		
				scale.x *= -1;
				firePoint.localScale = scale;
			}
		}



	}


}