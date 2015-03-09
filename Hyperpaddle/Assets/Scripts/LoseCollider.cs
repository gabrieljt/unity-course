using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public ScoreKeeper scoreKeeper;

	void OnTriggerEnter () {
		audio.Play();
		Invoke("NotifyScoreKeeper", 2);
	}

	void NotifyScoreKeeper () {
		scoreKeeper.BallOut();		
	}
}
