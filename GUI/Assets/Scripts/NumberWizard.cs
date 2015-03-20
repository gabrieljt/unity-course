using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	int max = 1001;
	int min = 1;
	int guess;
	public Text guessText;
	public LevelManager levelManager;
	
	void Start() 
	{
		NextGuess();
	}

	public void GreaterThan()
	{
		min = guess;
		NextGuess();
	}

	public void LesserThan()
	{
		max = guess;
		NextGuess();
	}

	public void EqualTo()
	{
		levelManager.LoadLevel("Win Screen");
	}

	void NextGuess()
	{
		guess = Random.Range(min, max);
		guessText.text = guess.ToString();		
	}
}
