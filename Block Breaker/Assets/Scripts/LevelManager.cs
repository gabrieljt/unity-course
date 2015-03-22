using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
	{
		Debug.Log("New Level load: " + name);
        Brick.breakableCount = 0;
		Application.LoadLevel(name);
	}

    public void LoadLevel(int index)
    {
        Debug.Log("New Level load: " + name);
        Brick.breakableCount = 0;
        Application.LoadLevel(index);
    }

    public void LoadNextLevel()
    {
        LoadLevel(Application.loadedLevel + 1);
    }

	public void QuitRequest()
	{
		Debug.Log("Quit Game requested.");
		Application.Quit();
	}

    public void BrickDestroyed()
    {
        if (Brick.breakableCount == 0)
        {
            LoadNextLevel();
        }
    }

}
