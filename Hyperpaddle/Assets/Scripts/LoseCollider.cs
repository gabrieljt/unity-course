using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public ScoreKeeper scoreKeeper;
	public Ball ball;

	void OnTriggerEnter () {
		audio.Play();
		scoreKeeper.BallOut();
	}
}
