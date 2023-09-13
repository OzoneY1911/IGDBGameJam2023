using UnityEngine;
using System.Collections;
using static BulletPatterns;

public class PlayerEffects : MonoBehaviour
{
	[SerializeField] private float SlowMultiplier = 0.1f;
	[SerializeField] private float TimeForSlow = 4f;
	[SerializeField] private float TimeBigAndInvisible = 4f;
	[SerializeField] private float TimeFreeMove = 4f;
	[SerializeField] private Color InvisibleColor;
	[SerializeField] private Color DamagedColor;
	[SerializeField] private Color HealthColor;
	private bool IsImmortal = false;
	private bool IsSlowed = false;
	private bool IsFreeMove = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.gameObject.CompareTag("Note"))
			return;

		BulletType effectType = collision.gameObject.GetComponent<Note>().Type;

		if (IsImmortal && effectType == BulletType.Standart)
		{
			collision.gameObject.SetActive(false);
			BulletSpawner.instance.AddBulletToPool(collision.gameObject);
			return;
		}

		switch (effectType)
		{
			case BulletType.Standart:
				AudioManager.instance.PlaySFX(AudioManager.sfxEnum.grannyHit);
				GetComponent<PlayerHealth>().Health -= 1;
				StartCoroutine(ChangePlayerColor(0.2f, DamagedColor));
				break;
			case BulletType.HpIncrease:
				GetComponent<PlayerHealth>().Health += 1;
				StartCoroutine(ChangePlayerColor(0.2f, HealthColor));
				break;
			case BulletType.SlowTime:
				if (!IsSlowed)
					StartCoroutine(SlowTime(TimeForSlow, SlowMultiplier));
				break;
			case BulletType.BiggerInvisiblePlayer:
				if (!IsImmortal)
					StartCoroutine(BigAndInvisible(TimeBigAndInvisible));
				break;
			case BulletType.FreeMovement:
				if (!IsFreeMove)
					StartCoroutine(FreeMove(TimeFreeMove));
				break;
		}

		collision.gameObject.SetActive(false);
		BulletSpawner.instance.AddBulletToPool(collision.gameObject);
	}

	private IEnumerator ChangePlayerColor(float time, Color color)
	{
		gameObject.GetComponent<SpriteRenderer>().color = color;
		yield return new WaitForSeconds(time);
		gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
	}

	private IEnumerator FreeMove(float time)
	{
		IsFreeMove = true;
		GetComponent<PlayerMovement>().freeMovement = true;
		yield return new WaitForSeconds(time);
		GetComponent<PlayerMovement>().freeMovement = false;
		IsFreeMove = false;
	}

	// slow time for a certain period of time
	private IEnumerator SlowTime(float time, float TimeMultiplier)
	{
		IsSlowed = true;
		Time.timeScale = TimeMultiplier;
		yield return new WaitForSeconds(time);
		Time.timeScale = 1;
		IsSlowed = false;
	}

	// do player big and invisible for a certain period of time
	private IEnumerator BigAndInvisible(float time)
	{
		IsImmortal = true;
		gameObject.transform.localScale *= 2;
		gameObject.GetComponent<SpriteRenderer>().color = InvisibleColor;
		yield return new WaitForSeconds(time);
		gameObject.transform.localScale /= 2;
		gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
		IsImmortal = false;
	}
}
