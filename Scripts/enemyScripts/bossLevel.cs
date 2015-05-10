using UnityEngine;
using System.Collections;

public class bossLevel : MonoBehaviour {

	public bossScript boss; 				//reference to the boss script
	
	public Object[] enemiesTop;				//an array of the top enemied
	public Object[] platformsTop;			//an array of the top platforms
	public Object[] enemiesBot;				//an array of the bottom enemeies
	public Object[] platformsBot;			//an array of the bottom platforms


	bool doneTop = false;					//check if your done with the top part
	bool doneBot = false;					//check if your done with the bottom part

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if your not done with the top part
		if (!doneTop) {
			//then check if all the top enemeies are dead
			if (checkIfNull (enemiesTop)) {
				//if they are then your done with the top
				doneTop = true;
				//and destroy the top platforms
				foreach (Object platform in platformsTop) {
					Destroy (platform);
				}
			}
		}
		//if your not done with the bottom part
		if (!doneBot) {
			//check if the bottom enemies are dead
			if(checkIfNull(enemiesBot)){
				//if they are then start the boss battle
				boss.startBoss();
				//and your done with the bot
				doneBot = true;
				//and destroy the bottom platforms
				foreach (Object platform in platformsBot) {
					Destroy (platform);
				}
			}
		
		}

	}


	//used to check if there are any non null elements in an array
	//because after an enemy dies their space in the array is null
	bool checkIfNull(Object[] array){
		for (int i = 0; i < array.Length; i++) {
				
			if(array[i] != null)
				return false;
		
		}
		return true;
	}
}
