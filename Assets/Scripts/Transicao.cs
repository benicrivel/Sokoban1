using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transicao : MonoBehaviour
{
    public string CenaName;
    public bool OpenScene = true;
    public GameObject[] Base, Cubo, Target;
    public GameObject Principal;
    public float t = 1.0f;
    public float DeltaT;
    // Update is called once per frame
    void Update()
    {

        float tf = (2.0f + DeltaT);
        if (t < tf)
        {
            t = t + Time.deltaTime;
        }
        else
        {
            t = tf;
        }

        if (t < 1.0f)
        {
            Base = GameObject.FindGameObjectsWithTag("Base");
            Target = GameObject.FindGameObjectsWithTag("Target");
            Cubo = GameObject.FindGameObjectsWithTag("Cubo");
            Principal = GameObject.FindGameObjectWithTag("Principal");

            for (int i = 0; i < Base.Length; i++)
            {
                Base[i].transform.localScale = new Vector3(0.95f * (1.0f - t), 0.1f * (1.0f - t), 0.95f * (1.0f - t));
            }

            for (int i = 0; i < Target.Length; i++)
            {
                Target[i].transform.localScale = new Vector3(0.95f * (1.0f - t), 0.1f * (1.0f - t), 0.95f * (1.0f - t));
            }

            for (int i = 0; i < Cubo.Length; i++)
            {
                Cubo[i].transform.localScale = new Vector3(0.8f * (1.0f - t), 0.8f * (1.0f - t), 0.8f * (1.0f - t));
            }

            Principal.transform.localScale = new Vector3(1.0f * (1.0f - t), 1.0f * (1.0f - t), 1.0f * (1.0f - t));
        }

        if (t > 1.0f && t < (DeltaT + 1.0f))
        {
            if(OpenScene == false)
            {
                SceneManager.LoadScene(CenaName);
                OpenScene = true;
            }

            Base = GameObject.FindGameObjectsWithTag("Base");
            Target = GameObject.FindGameObjectsWithTag("Target");
            Cubo = GameObject.FindGameObjectsWithTag("Cubo");
            Principal = GameObject.FindGameObjectWithTag("Principal");

            for (int i = 0; i < Base.Length; i++)
            {
                Base[i].transform.localScale = new Vector3(0, 0, 0);
            }

            for (int i = 0; i < Target.Length; i++)
            {
                Target[i].transform.localScale = new Vector3(0, 0, 0);
            }

            for (int i = 0; i < Cubo.Length; i++)
            {
                Cubo[i].transform.localScale = new Vector3(0, 0, 0);
            }

            Principal.transform.localScale = new Vector3(0, 0, 0);
        }

        if (t > (DeltaT + 1.0f) && t < tf)
        {
            for (int i = 0; i < Base.Length; i++)
            {
                Base[i].transform.localScale = new Vector3(0.95f * (t - (DeltaT + 1.0f)), 0.1f * (t - (DeltaT + 1.0f)), 0.95f * (t - (DeltaT + 1.0f)));
            }

            for (int i = 0; i < Target.Length; i++)
            {
                Target[i].transform.localScale = new Vector3(0.95f * (t - (DeltaT + 1.0f)), 0.1f * (t - (DeltaT + 1.0f)), 0.95f * (t - (DeltaT + 1.0f)));
            }

            for (int i = 0; i < Cubo.Length; i++)
            {
                Cubo[i].transform.localScale = new Vector3(0.8f * (t - (DeltaT + 1.0f)), 0.8f * (t - (DeltaT + 1.0f)), 0.8f * (t - (DeltaT + 1.0f)));
            }

            Principal.transform.localScale = new Vector3(1.0f * (t - (DeltaT + 1.0f)), 1.0f * (t - (DeltaT + 1.0f)), 1.0f * (t - (DeltaT + 1.0f)));
        }

    }

    public void IniciarTransicao(string Cena)
    {
        CenaName = Cena;
        OpenScene = false;
        t = 0.0f;
    }
}
