using UnityEngine;
using System.Collections;
using System.IO;

public class LocalScoreboard : MonoBehaviour {

	void Start () {
		string filePath = Path.Combine(Application.persistentDataPath, "hyperpaddle-scores.txt");
		Debug.Log(filePath);
		Stream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
		StreamWriter fileWriter = new StreamWriter(file);
		fileWriter.Write("Hello World");
		fileWriter.Close();

		file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
		StreamReader fileReader = new StreamReader(file);
		Debug.Log(fileReader.ReadToEnd());
		fileReader.Close();
	}
	
	void Update () {
	
	}
}
