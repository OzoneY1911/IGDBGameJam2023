using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] private GameObject DeathCanvas;
	[SerializeField] private int HealthPoints = 100;

	public int Health
	{
		get { return HealthPoints; }
		set {
			HealthPoints = value;
			if (HealthPoints <= 0)
				Death();
		}
	}

    void Death()
    {
        GetComponent<PlayerMovement>().enabled = false;
		BulletSpawner.instance.enabled = false;
		GameController.instance.enabled = false;
		DeathCanvas.SetActive(true);
	}

}
