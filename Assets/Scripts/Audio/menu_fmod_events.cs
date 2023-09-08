using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class menu_fmod_events : MonoBehaviour
{
    [field: Header("button_sounds")]
    [field: SerializeField] public EventReference hover_button { get; private set; }
    [field: SerializeField] public EventReference click_button { get; private set; }

    public static menu_fmod_events instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one fmod events instance in scene");
        }
        instance = this;
    }
}
