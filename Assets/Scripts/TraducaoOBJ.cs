using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraducaoOBJ : MonoBehaviour
{
    public GameObject[] Texto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Texto[FileBasedPrefs.GetInt("Idioma")].SetActive(true);
    }
}
