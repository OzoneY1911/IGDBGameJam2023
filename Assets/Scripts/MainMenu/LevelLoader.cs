using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	public static LevelLoader instance;

	private void Start()
	{
		instance = this;
	}

	public void LoadLevel(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}
}
