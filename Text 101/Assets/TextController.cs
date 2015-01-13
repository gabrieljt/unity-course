using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
		text.text = "Hello world!";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
			text.text = "Voce acorda num quarto escuro, aos poucos e com dificuldades. O corpo dolorido." +
				" Apenas uma luz fraca de cor amarela entra por uma fresta na parede, mas e o suficiente" +
				" para enxergar o contorno de alguns objetos no quarto. Nao se lembra de nada antes de acordar" +
				" e com algum esforco consegue se lembrar do seu nome. Passados uns minutos, decide se levantar." +
				" O quarto e pequeno. Alem da fresta na parede, voce avista um bau num canto do quarto, uma mesa" +
				" e um espelho pendurado na parede. Nao parece haver uma porta...";
	}
}
