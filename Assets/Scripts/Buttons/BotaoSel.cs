using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoSel : MonoBehaviour
{
    public int Nivel;
    // Start is called before the first frame update
    void Start()
    {
        FileBasedPrefs.SetInt("Level Max", 50);

        int levelmax = FileBasedPrefs.GetInt("Level Max");

        if (Nivel > levelmax)
        {
            GetComponent<Button>().interactable = false;
        }

        transform.GetChild(0).transform.GetComponent<Text>().text = Nivel.ToString();
    }
}
