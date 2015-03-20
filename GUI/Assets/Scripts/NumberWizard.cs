using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	public int max;
	public int min;
	public int guess;
	public Text guessText;
	public LevelManager levelManager;
	
	void Start() 
	{
		max = 1001;
		min = 1;
		guess = 500;
		SetGuessText();
	}

	void Update() 
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))
			GreaterThan();
		else if (Input.GetKeyDown(KeyCode.DownArrow))
			LesserThan();
		else if (Input.GetKeyDown(KeyCode.Space))
			EqualTo();
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
