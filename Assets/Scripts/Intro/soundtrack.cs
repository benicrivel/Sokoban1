using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundtrack : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().volume = FileBasedPrefs.GetFloat("Volume Soundtrack");
    }
}
