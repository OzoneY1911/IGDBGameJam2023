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
        SceneManager.LoadScene(levelName);

        switch (levelName)
		{
			case "MainMenu":
                Destroy(AudioManager.instance.gameObject);
				break;
            case "Level1":
                AudioManager.instance.PlayMusic(AudioManager.musicEnum.beatOne);
				AudioManager.instance.musicSource.loop = false;
                break;
        }
    }
}
