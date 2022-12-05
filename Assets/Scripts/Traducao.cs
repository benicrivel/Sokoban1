using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traducao : MonoBehaviour
{
    public string[] Texto;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = Texto[FileBasedPrefs.GetInt("Idioma")];

    }
}
