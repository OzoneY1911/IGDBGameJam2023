using System;
using UnityEngine;
using static BulletPatterns;

public class Note : MonoBehaviour
{
    [Header("Position")]
    [SerializeField] Vector2 startPoint;
    [SerializeField] Vector2 endPoint;
    [SerializeField] float shiftStartPoint;

    [Header("Speed")]
    [SerializeField] float Speed = 5f;

    [Header("Note Size")]
    [SerializeField] float Size = 1f;

	[NonSerialized] public BulletType Type;
	private Sprite sprite;

	void OnEnable()
    {
        transform.localScale = new Vector2(Size, Size);

        startPoint += (shiftStartPoint * (endPoint - startPoint).normalized);
        transform.position = startPoint;
        GetComponent<SpriteRenderer>().sprite = sprite;
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

    public void Init(in Vector2 startPoint, in Vector2 endPoint, in float shiftStartPoint, in float noteSpeed, in float noteSize, in BulletType noteType, in Sprite noteSprite)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.shiftStartPoint = shiftStartPoint;
        this.sprite = noteSprite;
        Speed = noteSpeed;
        Size = noteSize;
        Type = noteType;

        OnEnable();
    }
}
