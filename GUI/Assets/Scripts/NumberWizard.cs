using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	public int max;
	public int min;
	public int guess;
	public Text guessText;
	public LevelManager levelManager;
	
	void Start() {
		max = 1001;
		min = 1;
		guess = 500;
		SetGuessText();
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
		guess = (max + min) / 2;
		SetGuessText();
	}

	void SetGuessText()
	{
		guessText.text = guess.ToString();		
	}
}
