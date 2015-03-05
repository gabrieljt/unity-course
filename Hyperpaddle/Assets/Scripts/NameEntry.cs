using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NameEntry : MonoBehaviour {

	public InputField inputField;
	public Button submit;
	public Scoreboard scoreboard;

	// Use this for initialization
	void Start () {
		submit.onClick.AddListener(OnSubmitName);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnSubmitName () {
		string name = inputField.text;
		if (!string.IsNullOrEmpty(name))
			scoreboard.ClaimCurrentScore(name);
	}
}
