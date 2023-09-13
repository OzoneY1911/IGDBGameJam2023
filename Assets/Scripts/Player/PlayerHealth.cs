using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] private GameObject DeathCanvas;
	[SerializeField] private int HealthPoints = 3;

	public int Health
	{
		get { return HealthPoints; }
		set {
<<<<<<< Updated upstream
			if ( value < 3) {
				if (value < HealthPoints)
					levelOneAudioManager.instance.playOneShot(levelOneFmodEvents.instance.grannyHit, this.transform.position);
				HealthPoints = value;
			}
=======
      if ( value < 3) {
          HealthPoints = value;
      }
>>>>>>> Stashed changes
			else
				HealthPoints = 3;
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
