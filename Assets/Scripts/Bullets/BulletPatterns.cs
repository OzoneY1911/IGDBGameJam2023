using UnityEngine;
using System;
using System.Collections.Generic;

// a class that stores information about all the bullets that should be fired during the game
[CreateAssetMenu(fileName = "NewBulletPatterns", menuName = "BulletPatterns")]
public class BulletPatterns : ScriptableObject
{
    public float BPM;
	// coordinates of the upper left border of the playing field
	public Vector2 UpperBoundOfPlayingField;
	// coordinates of the down left border of the playing field
	public Vector2 DownBoundOfPlayingField;
	// coordinates of the x of right border of the playing field
	public int RightBoundOfPlayingField;

	// there is usually a constant amount of time between two beats in ms
	[NonSerialized] public float TimeBetweenEveryBeat;

	// every beat usually has 4 micro beats
	[NonSerialized] public float TimeBetweenEveryMicroBeat;

	// an array that stores all the data about different bullets
	public List<BulletPattern> bulletPatterns = new List<BulletPattern>();

	// every bullet can be described in this class
	[Serializable] public class BulletPattern
	{
		// bullet beat on which the bullet must reach the player
		public int BeatWhenReachPlayer;

		// bullet micro beat on which the bullet must reach the player
		[Range(0, 3)] public int MicroBeatWhenReachPlayer;
		
		public float Speed = 1;
		
		public float Size = 0.5f;

		// the initial position of the bullet is determined by how far it is deviated from the centre in down/up of the left side of the playing field
		[Range(-1, 1)] public float CentreSideDeviation = 0; // if -1 its fully up if 1 its fully down if 0 it fully cetre

		// how much time must elapse since the beginning of the music to release the bullet on the playing field so that the bullet can reach the player at a certain beat
		[NonSerialized] public float TimeWhenReleased;

		// initial position, specified as a vector to be given to the point
		[NonSerialized] public Vector2 StartTransform;

		// how many ms must elapse from the beginning of the song for the bullet to reach the player
		[NonSerialized] public float ReachTime;
	}

	// calls on start
	private void OnEnable()
	{
		TimeBetweenEveryBeat = 60000f / BPM;
        TimeBetweenEveryMicroBeat = TimeBetweenEveryBeat / 4f;
		foreach (var pattern in bulletPatterns)
		{
			pattern.StartTransform = new Vector2(UpperBoundOfPlayingField.x, Mathf.Lerp(UpperBoundOfPlayingField.y, DownBoundOfPlayingField.y, (pattern.CentreSideDeviation + 1f) / 2f));
			pattern.ReachTime = pattern.BeatWhenReachPlayer * TimeBetweenEveryBeat + pattern.MicroBeatWhenReachPlayer * TimeBetweenEveryMicroBeat;

			float distantionToPass = GetDistanceBetweenTwoPoints(pattern.StartTransform, new Vector2(pattern.StartTransform.x + RightBoundOfPlayingField, pattern.StartTransform.y));
			pattern.TimeWhenReleased = pattern.ReachTime - distantionToPass / pattern.Speed * 1000/*convert to ms*/;
		}
	}

	// calculates the distance between two points, taking into account the collision from the collider
	private float GetDistanceBetweenTwoPoints(in Vector2 firstPoint, in Vector2 secondPoint)
	{
		// creating ray between firstPoint and secondPoint
		Vector2 lineDirection = secondPoint - firstPoint;
		RaycastHit2D hit = Physics2D.Raycast(firstPoint, lineDirection.normalized, lineDirection.magnitude);

		if (hit.collider != null) // if collided with something return distance considering this collision
		{
			return Mathf.Abs(hit.point.x - firstPoint.x);
		} else
		{
			return Mathf.Abs(secondPoint.x - firstPoint.x);
		}
	}
}
