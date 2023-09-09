using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour, IPointerEnterHandler
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => ClickButton());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MenuAudioManager.instance.PlaySound(MenuFMODEvents.instance.hover_button, transform.position);
    }

    public void ClickButton()
    {
        MenuAudioManager.instance.PlaySound(MenuFMODEvents.instance.click_button, transform.position);
    }
}