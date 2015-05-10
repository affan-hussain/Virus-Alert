using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class pathDefinition : MonoBehaviour {


	public Transform[] Points; // an array of the points in the path



	//this IEnumerator block is used to cycle through the points
	public IEnumerator<Transform> GetPathsEnumerator(){
		//if there are no point dont do anything
		if (Points == null || Points.Length < 1)  
						yield break;

		var direction = 1;
		var index = 0;

		//this while statement does the actual cycling
		while (true) {
				
			yield return Points[index]; 
		
			if(Points.Length == 1)
				continue;

			if(index <= 0)
				direction = 1;
			else if(index >= Points.Length - 1)
				direction = -1;

			index = index + direction;

		}

	}


	//this is being used to draw a line showing the path
	public void OnDrawGizmos(){
		if (Points == null || Points.Length < 2)
						return;

		for (int i = 1; i < Points.Length; i++) {
			Gizmos.DrawLine(Points[i-1].position, Points[i].position);
		}
	}


}
