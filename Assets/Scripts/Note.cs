using UnityEngine;

public class Note : MonoBehaviour
{
    [Header("Position")]
    [SerializeField] Vector2 startPoint;
    [SerializeField] Vector2 endPoint;
    [SerializeField] float shiftStartPointX;

    [Header("Speed")]
    [SerializeField] float noteSpeed = 5f;

    [Header("Note Size")]
    [SerializeField] float noteSize = 1f;

    void OnEnable()
    {
        transform.localScale = new Vector2(noteSize, noteSize);

        startPoint.x -= shiftStartPointX;
        transform.position = startPoint;
        gameObject.SetActive(true);
	}

	void Update()
    {
        // Move between two points
        if (gameObject.activeSelf)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint, noteSpeed * Time.deltaTime);
        }

        // If Note reaches endPoint
        if (transform.position.x == endPoint.x && transform.position.y == endPoint.y)
        {
            gameObject.SetActive(false);
            BulletSpawner.instance.AddBulletToPool(gameObject);
        }
    }

    public void Init(Vector2 startPoint, Vector2 endPoint, float shiftStartPointX, float noteSpeed, float noteSize)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.shiftStartPointX = shiftStartPointX;
        this.noteSpeed = noteSpeed;
        this.noteSize = noteSize;

        OnEnable();
    }
}
