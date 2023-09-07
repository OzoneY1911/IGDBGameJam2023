using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	public void LoadLevel(int levelNumber)
	{
		SceneManager.LoadScene("Levels" + '/' + levelNumber.ToString());
	}
}
