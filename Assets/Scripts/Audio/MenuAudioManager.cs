using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MenuAudioManager : MonoBehaviour
{
   internal static MenuAudioManager instance;

   void Awake()
   {
        instance = this;
   }

   public void PlaySound(EventReference sound, Vector3 worldPos)
   {
        RuntimeManager.PlayOneShot(sound, worldPos);
   }
}
