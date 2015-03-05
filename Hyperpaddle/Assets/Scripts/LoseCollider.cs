using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public ScoreKeeper scoreKeeper;
	public Ball ball;

	void OnTriggerEnter () {
		audio.Play();
		Invoke("NotifyScoreKeeper", 2);
	}

	void NotifyScoreKeeper () {
		scoreKeeper.BallOut();		
	}
}
