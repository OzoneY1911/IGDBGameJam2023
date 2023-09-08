using UnityEngine;
using UnityEngine.Pool;
using static BulletPatterns;

public class BulletSpawner : MonoBehaviour
{
	[SerializeField] private GameObject _BulletPrefab;
	[SerializeField] private BulletPatterns _BulletPatterns;
	private ObjectPool<GameObject> BulletsPool;

	private void Start()
	{
		BulletsPool = new ObjectPool<GameObject>(() => Instantiate(_BulletPrefab));
	}

	void Update()
    {
		float CurrentTime = Time.time * 1000;
		foreach (var bulletPattern in _BulletPatterns.bulletPatterns)
		{
			if (IsNeedToSpawn(bulletPattern, CurrentTime))
			{
				
			}
		}
    }

	private float CalculateDeviationFromStart(in BulletPattern Pattern, in float CurrentTime)
	{
		return (CurrentTime - Pattern.TimeWhenReleased) * Pattern.Speed;
	}

	private bool IsNeedToSpawn(in BulletPattern Pattern, in float CurrentTime)
	{
		return (Pattern.TimeWhenReleased < CurrentTime);
	}
}
