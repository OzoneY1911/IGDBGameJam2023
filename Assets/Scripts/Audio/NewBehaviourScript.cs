using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void test()
    {
        menu_audio_manager.instance.PlayOneShot(menu_fmod_events.instance.click_button, this.transform.position);
    }
}
