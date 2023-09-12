using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class levelOneFmodEvents : MonoBehaviour
{
    [field: Header("grannySfx")]
    [field: SerializeField] public EventReference grannyHit { get; private set; }

    public static levelOneFmodEvents instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one fmodEvents instance in scene");
        }
        instance = this;
    }
}
