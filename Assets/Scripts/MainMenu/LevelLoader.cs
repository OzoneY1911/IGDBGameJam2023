using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	internal static LevelLoader instance;

	void Awake()
	{
		instance = this;
	}

	public void LoadLevel(string levelName)
	{
		AudioManager.instance.StopMusic();
		SceneManager.LoadScene(levelName);
    }
}
