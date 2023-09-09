using UnityEngine;
using System.Collections;
using static BulletPatterns;

public class PlayerEffects : MonoBehaviour
{
	[SerializeField] private float SlowMultiplier = 0.1f;
	[SerializeField] private float TimeForSlow = 4f;
	[SerializeField] private float TimeBigAndInvisible = 4f;
	[SerializeField] private Color InvisibleColor;
	private bool IsImmortal = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.gameObject.CompareTag("Note"))
			return;

		if (IsImmortal)
		{
			collision.gameObject.SetActive(false);
			BulletSpawner.instance.AddBulletToPool(collision.gameObject);
			return;
		}

		switch (collision.gameObject.GetComponent<Note>().Type)
		{
			case BulletType.Standart:
				GetComponent<PlayerHealth>().Health -= 50;
				break;
			case BulletType.HpIncrease:
				GetComponent<PlayerHealth>().Health += 50;
				break;
			case BulletType.SlowTime:
				StartCoroutine(SlowTime(TimeForSlow, SlowMultiplier));
				break;
			case BulletType.BiggerInvisiblePlayer:
				StartCoroutine(BigAndInvisible(TimeBigAndInvisible));
				break;
		}

		collision.gameObject.SetActive(false);
		BulletSpawner.instance.AddBulletToPool(collision.gameObject);
	}

	// slow time for a certain period of time
	private IEnumerator SlowTime(float time, float TimeMultiplier)
	{
		Time.timeScale = TimeMultiplier;
		yield return new WaitForSeconds(time);
		Time.timeScale = 1;
	}

	// do player big and invisible for a certain period of time
	private IEnumerator BigAndInvisible(float time)
	{
		gameObject.transform.localScale *= 2;
		gameObject.GetComponent<SpriteRenderer>().color = InvisibleColor;
		IsImmortal = true;
		yield return new WaitForSeconds(time);
		gameObject.transform.localScale /= 2;
		gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
		IsImmortal = false;
	}
}
