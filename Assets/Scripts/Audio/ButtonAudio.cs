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
        AudioManager.instance.PlaySFX(AudioManager.sfxEnum.menuHover);
    }

    public void ClickButton()
    {
        AudioManager.instance.PlaySFX(AudioManager.sfxEnum.menuClick);
    }
}