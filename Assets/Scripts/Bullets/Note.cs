using System;
using UnityEngine;
using static BulletPatterns;

public class Note : MonoBehaviour
{
    [Header("Position")]
    [SerializeField] Vector2 startPoint;
    [SerializeField] Vector2 endPoint;
    [SerializeField] float shiftStartPoint;
    [SerializeField] Sprite defaultSprite;

    [Header("Speed")]
    [SerializeField] float Speed = 5f;

    [Header("Note Size")]
    [SerializeField] float Size = 1f;

	[NonSerialized] public BulletType Type;
	private Sprite sprite;
	private uint number;

	void OnEnable()
    {
        transform.localScale = new Vector2(Size, Size);

        startPoint += (shiftStartPoint * (endPoint - startPoint).normalized);
        transform.position = startPoint;
        if (sprite == null)
        {
			GetComponent<SpriteRenderer>().sprite = defaultSprite;
			gameObject.GetComponent<BoxCollider2D>().size = defaultSprite.bounds.size / 1.5f;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = sprite;
			gameObject.GetComponent<BoxCollider2D>().size = gameObject.GetComponent<SpriteRenderer>().bounds.size / 1.5f;
		}
		gameObject.name = number.ToString();
			gameObject.SetActive(true);
	}

	void Update()
    {
        // Move between two points
        if (gameObject.activeSelf)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint, Speed * Time.deltaTime * Time.timeScale);
        }

        // If Note reaches endPoint
        if (transform.position.x == endPoint.x && transform.position.y == endPoint.y)
        {
            gameObject.SetActive(false);
            BulletSpawner.instance.AddBulletToPool(gameObject);
        }
    }

    public void Init(in Vector2 startPoint, in Vector2 endPoint, in float shiftStartPoint, in float noteSpeed, in float noteSize, in BulletType noteType, in Sprite noteSprite, in uint number)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.shiftStartPoint = shiftStartPoint;
        this.sprite = noteSprite;
        this.number = number;
        Speed = noteSpeed;
        Size = noteSize;
        Type = noteType;

        OnEnable();
    }
}
