using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
    public Material material, chao, target;

    public Texture[] textures;
    public Color[] MainColor;
    public Color[] EmissionColor;

    public bool Menu;
    // Start is called before the first frame update
    void Start()
    {
        if(Menu == false)
        {
            int index = Random.Range(0, textures.Length);
            material.mainTexture = textures[index];

            chao.color = MainColor[index];
            target.color = MainColor[index];
            target.SetColor("_EmissionColor", EmissionColor[index]);
        }
        else
        {
            material.mainTexture = textures[4];
            chao.color = MainColor[4];
            target.color = MainColor[4];
            target.SetColor("_EmissionColor", EmissionColor[4]);
        }
    }
}
