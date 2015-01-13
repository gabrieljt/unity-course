using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {room, room_0, wall_crack_0, chest_0, table_0, mirror_0, freedom}
	private States currentState;

	// Use this for initialization
	void Start () {
		currentState = States.room;
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentState) {
		case States.room:
			state_room();
			break;
		case States.room_0:
			state_room_0();
			break;
		case States.wall_crack_0:
			state_wall_crack_0();
			break;
		}
	}

	void state_room () {
		text.text = "Voce acorda num quarto escuro, aos poucos e com dificuldades. O corpo dolorido." +
				" Apenas uma luz fraca de cor amarela entra por uma fresta na parede, mas e o suficiente" +
				" para enxergar o contorno de alguns objetos no quarto. Nao se lembra de nada antes de acordar" +
				" e com algum esforco consegue se lembrar do seu nome. Passados uns minutos, decide se levantar." +
				" O quarto e pequeno. Alem da fresta na parede, voce avista um bau num canto do quarto, uma mesa" +
				" e um espelho pendurado na parede. Nao parece haver uma porta...\n\n" +
				" Pressione F para observar a Fresta; B para observar o Bau; M para observar a Mesa; E" +
				" para observar o Espelho.";
		if (Input.GetKeyDown(KeyCode.F))
			currentState = States.wall_crack_0;
	}

	void state_room_0 () {
		text.text = " Voce avista uma fresta na parede, um bau num canto do quarto, uma mesa" +
				" e um espelho pendurado na parede. Nao parece haver uma porta...\n\n" +
				" Pressione F para observar a Fresta; B para observar o Bau; M para observar a Mesa; E" +
				" para observar o Espelho.";
		if (Input.GetKeyDown(KeyCode.F))
			currentState = States.wall_crack_0;
	}

	void state_wall_crack_0 () {
		text.text = "A fresta nao e grande o suficiente para enxergar muita coisa do outro lado. Fora que" +
				" a luz, apesar de fraca, ofusca sua visao. Mas nao parece ser um lugar aberto do outro lado desta" +
				" parede...\n\n" +
				" Pressione V para Voltar a observar o quarto.";
		if (Input.GetKeyDown(KeyCode.V))
			currentState = States.room_0;
	}
}
