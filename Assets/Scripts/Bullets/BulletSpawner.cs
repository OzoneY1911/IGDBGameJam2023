using System;
using UnityEngine;
using UnityEngine.Pool;
using static BulletPatterns;

// singletone class that spawns bullet in the playing field
public class BulletSpawner : MonoBehaviour
{
	internal static BulletSpawner instance;

	[SerializeField] private GameObject _BulletPrefab;
	[SerializeField] private BulletPatterns _BulletPatterns;
	[SerializeField] private GameObject WinCanvas;
	[SerializeField] private GameObject Player;
	private ObjectPool<GameObject> BulletsPool;
	private float StartTime; // time when songs starts

	void Awake()
    {
		instance = this;
    }

    void Start()
	{
		// inits
		BulletsPool = new ObjectPool<GameObject>(() => Instantiate(_BulletPrefab));
		StartTime = Time.time;
		foreach (var bulletPattern in _BulletPatterns.bulletPatterns)
		{
			bulletPattern.IsSpawned = false;
		}
	}

	void Update()
    {
		if (Time.timeScale != 1)
		{
			StartTime += Time.deltaTime * Time.timeScale;
		}

		float CurrentTime = Time.time * 1000 - StartTime * 1000; // calculates current time in ms

		if (_BulletPatterns.SongLength * 1000 < CurrentTime)
		{
			Player.GetComponent<PlayerMovement>().enabled = false;
			this.enabled = false;
			GameController.instance.enabled = false;
			WinCanvas.SetActive(true);
		}

		foreach (var bulletPattern in _BulletPatterns.bulletPatterns)
		{
			if (IsNeedToSpawn(bulletPattern, CurrentTime)) // check if need to spawn then get bullet from pool and init
			{
				bulletPattern.IsSpawned = true;
				GameObject NewBullet = BulletsPool.Get();
				NewBullet.GetComponent<Note>().Init(bulletPattern.StartTransform, bulletPattern.EndPosition, 
					CalculateDeviationFromStart(bulletPattern, CurrentTime), bulletPattern.Speed, 
					bulletPattern.Size, bulletPattern.Type, bulletPattern.Sprite, bulletPattern.Number
					);
			}
		}
    }

	// add used bullet back to pool
	public void AddBulletToPool(GameObject Bullet)
	{
		BulletsPool.Release(Bullet);
	}

	// finds out at what starting position the bullet needs to be spawned, taking into account the delay between frames
	private float CalculateDeviationFromStart(in BulletPattern Pattern, in float CurrentTime)
	{
		return (Pattern.TimeWhenReleased - CurrentTime) / Pattern.Speed;
	}

	// check if bullet need to spawn now
	private bool IsNeedToSpawn(in BulletPattern Pattern, in float CurrentTime)
	{
		return !Pattern.IsSpawned && (Pattern.TimeWhenReleased < CurrentTime);
	}
}
