using UnityEngine;
using FMODUnity;

public class MenuFMODEvents : MonoBehaviour
{
    internal static MenuFMODEvents instance;

    [Header("button_sounds")]
    public EventReference hover_button;
    public EventReference click_button;

    [Header("menu_music")]
    public EventReference menu_chords;

    void Awake()
    {
        instance = this;
    }
}
