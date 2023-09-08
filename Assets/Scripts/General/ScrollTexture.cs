using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    [SerializeField] float scrollSpeed;

    void FixedUpdate()
    {
        transform.localPosition += new Vector3(0f, -scrollSpeed * Time.fixedDeltaTime, 0f);

        if (transform.localPosition.y < -Screen.height)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Screen.height, transform.localPosition.z);
        }
    }
}
