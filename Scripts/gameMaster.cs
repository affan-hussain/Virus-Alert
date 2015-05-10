using UnityEngine;
using System.Collections;

public class gameMaster : MonoBehaviour {

	public static gameMaster gm;		 //the game master object
	public Transform playerPrefab;       //the player 


	//set the screen resolution to 720p , not fullscreen, 30fps
	void Awake(){

		Screen.SetResolution (1280,720,false,30);
	}

	//find the game master component
	void Start(){
		if (gm == null)
			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<gameMaster>();
	}




	//destroy the player object
	public static void killPlayer(Player player){
		Destroy (player.gameObject);
	}




}
