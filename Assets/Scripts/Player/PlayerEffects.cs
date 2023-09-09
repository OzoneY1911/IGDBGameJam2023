using UnityEngine;
using static BulletPatterns;

public class PlayerEffects : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.gameObject.CompareTag("Note"))
			return;

		switch (collision.gameObject.GetComponent<Note>().Type)
		{
			case BulletType.Standart:
				GetComponent<PlayerHealth>().Health -= 50;
				break;
			case BulletType.HpIncrease:
				GetComponent<PlayerHealth>().Health += 50;
				break;
			case BulletType.SlowTime:
				SlowTime(4);
				break;
			case BulletType.BiggerInvisiblePlayer:
				BigAndInvisible(4);
				break;
		}
	}

	// slow time for a certain period of time
	private void SlowTime(in float time)
	{

	}

	// do player big and invisible for a certain period of time
	private void BigAndInvisible(in float time)
	{

	}
}
