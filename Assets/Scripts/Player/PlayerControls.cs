using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            LevelLoader.instance.LoadLevel("Scenes/MainMenu");
        else if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
