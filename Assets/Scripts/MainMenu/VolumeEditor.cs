using UnityEngine;

public enum VolumeType : byte
{
    Music,
    Effects
}

public class VolumeEditor : MonoBehaviour
{

    public void EditMusicVolume(float volume) 
    {
        PlayerPrefs.SetFloat("MusicVolume", volume); 
	}

	public void EditEffectsVolume(float volume)
	{
		PlayerPrefs.SetFloat("EffectsVolume", volume);
	}
}
