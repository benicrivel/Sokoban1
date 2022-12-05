using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class Configuracoes : MonoBehaviour
{
    public Slider Soundtrack, Efeitos;
    public int Idioma;
    public GameObject[] BotoesGraficos;
    public RenderPipelineAsset[] QualityLevels;
    public GameObject[] PostProcessing;

    // Start is called before the first frame update
    void Start()
    {
        Soundtrack.value = FileBasedPrefs.GetFloat("Volume Soundtrack");
        Efeitos.value = FileBasedPrefs.GetFloat("Volume Efeitos");
        Idioma = FileBasedPrefs.GetInt("Idioma");

    }

    // Update is called once per frame
    void Update()
    {
        FileBasedPrefs.SetFloat("Volume Soundtrack", Soundtrack.value);
        FileBasedPrefs.SetFloat("Volume Efeitos", Efeitos.value);
        FileBasedPrefs.SetInt("Idioma", Idioma);

        int a = FileBasedPrefs.GetInt("Gráficos");

        for (int i = 0; i < 4; i++)
        {
            if(i == a)
            {
                BotoesGraficos[i].GetComponent<Image>().color = Color.yellow;
            }
            else
            {
                BotoesGraficos[i].GetComponent<Image>().color = Color.white;
            }
        }

        if (FileBasedPrefs.GetInt("Post Processing") == 1)
        {
            PostProcessing[1].SetActive(true);
            PostProcessing[0].SetActive(false);
        }
        else
        {
            PostProcessing[0].SetActive(true);
            PostProcessing[1].SetActive(false);
        }

    }

    public void PostProcessingChange()
    {
        if (FileBasedPrefs.GetInt("Post Processing") == 1)
        {
            FileBasedPrefs.SetInt("Post Processing", 0);
        }
        else
        {
            FileBasedPrefs.SetInt("Post Processing", 1);
        }
    }


    public void TelaCheia()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void IdiomaMais()
    {
        if(Idioma < 2)
        {
            Idioma = Idioma + 1;
        }
        else
        {
            Idioma = 0;
        }
    }

    public void IdiomaMenos()
    {
        if (Idioma > 0)
        {
            Idioma = Idioma - 1;
        }
        else
        {
            Idioma = 2;
        }
    }

    public void SetGraficos(int a)
    {
        FileBasedPrefs.SetInt("Gráficos", a);
        QualitySettings.SetQualityLevel(a);
        QualitySettings.renderPipeline = QualityLevels[a];
    }
}
