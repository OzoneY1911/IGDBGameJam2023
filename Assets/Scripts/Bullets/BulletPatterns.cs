using UnityEngine;
using System;
using System.Collections.Generic;

// a class that stores information about all the bullets that should be fired during the game
[CreateAssetMenu(fileName = "NewBulletPatterns", menuName = "BulletPatterns")]
public class BulletPatterns : ScriptableObject
{
    [SerializeField] public float BPM;

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

		// the initial position of the bullet is determined by how far it is deviated from the top of the playing field
		public float TopSideDeviation;

		// how much time must elapse since the beginning of the music to release the bullet on the playing field so that the bullet can reach the player at a certain beat
		[NonSerialized] public float TimeWhenReleased;

	}

	// calls on start
	private void OnEnable()
	{
        TimeBetweenEveryBeat = 60000f / BPM;
        TimeBetweenEveryMicroBeat = TimeBetweenEveryBeat / 4f;
		foreach (var pattern in bulletPatterns)
		{
			pattern.TimeWhenReleased = 0xABCDEF; // must be calculated taking into account the speed of the bullet,
													   // the position at which the bullet starts and taking into account
													   // the fact that it must get to a semicircle and not to a straight line
		}
	}
}
