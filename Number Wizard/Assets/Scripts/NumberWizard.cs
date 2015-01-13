using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	// Use this for initialization
	int max = 1000;
	int min = 1;
	int guess = 500;
	
	void Start () {
		StartGame();
	}

	void StartGame () {
		print ("Welcome to Number Wizard!");
		print ("Pick a number in your head, but don't tell me...");
		
		Debug.Log (string.Format("The highest number you can pick is {0}.", max));
		Debug.Log (string.Format("The lowest number you can pick is {0}.", min));
		
		// Round up
		++max;
		
		Guess();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			min = guess;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			max = guess;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			print ("I won!");	
		}
	}
	
	void Guess () {
		Debug.Log (string.Format("Is the number higher or lower than {0} ?", guess));
		print ("up = higher | down = lower | return = equal");
	}

	void NextGuess () {
		guess = (max + min) / 2;
		Guess();
	}
}