using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NameEntry : MonoBehaviour {

	public InputField inputField;
	public Button button;
	public LocalScoreboard scoreboard;
	public LevelManager levelManager;

	void Start () {
		button.onClick.AddListener(OnSubmitName);
	}
	
	void OnSubmitName () {
		string playerName = inputField.text;
		if (!string.IsNullOrEmpty(playerName)) {
			scoreboard.ClaimCurrentScore(playerName);
			levelManager.LoadLevel("Score Table");
		}
	}
}
