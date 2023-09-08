using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] private GameObject DeathCanvas;

    void Death()
    {
        GetComponent<PlayerMovement>().enabled = false;
		BulletSpawner.instance.enabled = false;
		DeathCanvas.SetActive(true);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Note"))
		{
			Death();
		}
	}
}
