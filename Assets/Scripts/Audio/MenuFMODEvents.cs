using UnityEngine;
using FMODUnity;

public class MenuFMODEvents : MonoBehaviour
{
    internal static MenuFMODEvents instance;

    [Header("button_sounds")]
    public EventReference hover_button;
    public EventReference click_button;

    void Awake()
    {
        instance = this;
    }
}
