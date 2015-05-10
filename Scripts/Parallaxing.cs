using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds;     //Array of all the backgounds to be parallaxed
	private float[] parallaxScales;    //proportion of the camera's movement to move the background by
	public float smoothing = 1f;        //controls how smooth the parallax will be must be greater than 0

	private Transform cam;              //reference to the main cameras transform
	private Vector3 previousCamPosition; // stores the position of the camera in the previous fram
	
	//is called before start().
	void Awake()
	{
		//set up the camera refference
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () 
	{
		//The previous frame will have the current frames position
		previousCamPosition = cam.position;

		parallaxScales = new float[backgrounds.Length];

		//set each background to the appropriate scale
		for (int i = 0; i<backgrounds.Length; i++) 
		{
			parallaxScales[i] = backgrounds[i].position.z*-1;
		}

	}
	
	// Update is called once per frame
	void Update () {
	//for each backgrounf
		for(int i = 0; i<backgrounds.Length; i++)
		{
			//the parallax is the opposite of the camera movement because it is multiplied by the scale
			float parallax = (previousCamPosition.x - cam.position.x) * parallaxScales[i];

			//set a target x position which is the current position plus the parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;


			//create a target position which is the backgrounds current position with its target x position
			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			// fade between current position and target position using lerp
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position,backgroundTargetPos,smoothing * Time.deltaTime);
		}

		//set the previousCamPos to the cameras postion at the end of the frame
		previousCamPosition = cam.position;
	}
}
