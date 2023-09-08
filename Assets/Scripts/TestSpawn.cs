using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    [SerializeField] GameObject notePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject noteClone = Instantiate(notePrefab, new Vector2(5, 0), transform.rotation);
            noteClone.GetComponent<Note>().Init(new Vector2(5, 0), new Vector2(0, 0), 0, 5f, 1f);
        }
    }
}
