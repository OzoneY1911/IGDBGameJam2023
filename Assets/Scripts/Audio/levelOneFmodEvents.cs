using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class levelOneFmodEvents : MonoBehaviour
{
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
