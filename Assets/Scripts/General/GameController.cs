using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    internal static GameController instance;
    [SerializeField] private TextMeshProUGUI ScoreText;
    private int Score = 0;
	private float StartTime = 0;

	void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Application.targetFrameRate = 90;
        StartTime = Time.time;
        Score = 0;
    }
	private void Update()
	{
        Score = Mathf.FloorToInt(Time.time - StartTime);
		ScoreText.text = Score.ToString();
	}
}
