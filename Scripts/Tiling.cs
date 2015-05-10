using UnityEngine;
using System.Collections;
[RequireComponent(typeof (SpriteRenderer))]
public class Tiling : MonoBehaviour {

	public int offSetX = 2;  // so that the buddy has been instantiated before reaching it
	public bool hasARightBuddy = false; //checks if right buddy has been created
	public bool hasALeftBuddy = false; // checks if left buddy has been created

	public bool reverseScale = false; // to make something untilable

	private float spriteWidth = 3f; //width of our element
	private Camera cam;
	private Transform aTransform;

	//function to create a buddy on the required side
	void makeNewBuddy(int direction)
	{
		// calculating position for the new buddy
		Vector3 newPosition = new Vector3 (aTransform.position.x  + spriteWidth  * direction,aTransform.position.y,aTransform.position.z);
		//instantiating new buddy in a Transform Variable
		Transform newBuddy =(Transform)Instantiate(aTransform, newPosition, aTransform.rotation);

		// if not tilable then reverse x size to make sprites connect Seamlessly
		if(reverseScale == true)
			newBuddy.localScale = new Vector3(newBuddy.localScale.x*-1,newBuddy.localScale.y,newBuddy.localScale.z);

		newBuddy.parent = aTransform.parent;

		if(direction > 0)
			newBuddy.GetComponent<Tiling>().hasALeftBuddy = true;
		else
			newBuddy.GetComponent<Tiling>().hasARightBuddy = true;
	}


	void Awake(){
		cam = Camera.main;
		aTransform = transform;
	}

	// Use this for initialization
	void Start () {
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
		spriteWidth = 8.85f; //because this was used only on sprite the width was just put in
	}
	
	// Update is called once per frame
	void Update () {
		//does it need a buddy if not do nothing
		if(hasALeftBuddy == false || hasARightBuddy == false)
		{   // calculate half the width of what the camera can see in world coordinates
			float camHorizontalExtent = cam.orthographicSize * Screen.width/Screen.height;

			//calculate the x position where the camera can see the edge of the sprite
			float edgeVisiblePositionRight = (aTransform.position.x + spriteWidth /2) - camHorizontalExtent;
			float edgeVisiblePositionLeft = (aTransform.position.x - spriteWidth /2) + camHorizontalExtent;


			//checking if we can see the edge of the element and then calling makeNewBuddy()
			if(cam.transform.position.x >= edgeVisiblePositionRight - offSetX && hasARightBuddy == false)
			{
				makeNewBuddy(1);
				hasARightBuddy = true;
			}
			else if(cam.transform.position.x <= edgeVisiblePositionLeft + offSetX && hasALeftBuddy == false)
			{
				makeNewBuddy(-1);
				hasALeftBuddy = true;
			}
		}


	}


}
