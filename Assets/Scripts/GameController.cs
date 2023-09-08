using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    internal static GameController instance;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Application.targetFrameRate = 60;
    }
}
