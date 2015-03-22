using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public int index;
    
    public void LoadLevel(string name)
	{
		Debug.Log("New Level load: " + name);
		Application.LoadLevel(name);
	}

    public void LoadLevel(int index)
    {
        Debug.Log("New Level load: " + name);
        Application.LoadLevel(index);
    }

    public void LoadNextLevel()
    {
        index++;
        LoadLevel(index);
    }

	public void QuitRequest()
	{
		Debug.Log("Quit Game requested.");
		Application.Quit();
	}

}
