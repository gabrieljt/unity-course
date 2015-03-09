using UnityEngine;
using System.Collections;

public class MultiplayerLoseCollider : MonoBehaviour {

	public ScoreKeeper scoreKeeper;
	
	void OnTriggerEnter () {
		audio.Play();
		Invoke("NotifyScoreKeeper", 2);
	}
	
	void NotifyScoreKeeper () {
		MultiplayerGame.NewRound();
		//scoreKeeper.BallOut();		
	}
}
