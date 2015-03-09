using UnityEngine;
using System.Collections;

public class MultiplayerLoseCollider : MonoBehaviour {

	public ScoreKeeper scoreKeeper;
	
	void OnTriggerEnter () {
		audio.Play();
		NotifyScoreKeeper();
	}
	
	void NotifyScoreKeeper () {
		MultiplayerGame.NewRound();
		//scoreKeeper.BallOut();		
	}
}
