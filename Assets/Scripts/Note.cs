using System;
using UnityEngine;
using static BulletPatterns;

public class Note : MonoBehaviour
{
    [Header("Position")]
    [SerializeField] Vector2 startPoint;
    [SerializeField] Vector2 endPoint;
    [SerializeField] float shiftStartPointX;

    [Header("Speed")]
    [SerializeField] float Speed = 5f;

    [Header("Note Size")]
    [SerializeField] float Size = 1f;

    [NonSerialized] public BulletType Type;

    void OnEnable()
    {
        transform.localScale = new Vector2(Size, Size);

        startPoint.x -= shiftStartPointX;
        transform.position = startPoint;
        gameObject.SetActive(true);
	}

	void Update()
    {
        // Move between two points
        if (gameObject.activeSelf)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint, Speed * Time.deltaTime);
        }

        // If Note reaches endPoint
        if (transform.position.x == endPoint.x && transform.position.y == endPoint.y)
        {
            gameObject.SetActive(false);
            BulletSpawner.instance.AddBulletToPool(gameObject);
        }
    }

    public void Init(in Vector2 startPoint, in Vector2 endPoint, in float shiftStartPointX, in float noteSpeed, in float noteSize, in BulletType noteType)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.shiftStartPointX = shiftStartPointX;
        this.Speed = noteSpeed;
        this.Size = noteSize;
        this.Type = noteType;

        OnEnable();
    }
}
