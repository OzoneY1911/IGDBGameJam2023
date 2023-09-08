using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class menu_audio_manager : MonoBehaviour
{
   public static menu_audio_manager instance { get; private set; }

   private void Awake()
   {
    if(instance != null)
    {
        Debug.LogError("More than one audio manager in scene");
    }
    instance = this;
   }

   public void PlaySound(EventReference sound, Vector3 worldPos)
   {
    RuntimeManager.PlayOneShot(sound, worldPos);
   }
}
