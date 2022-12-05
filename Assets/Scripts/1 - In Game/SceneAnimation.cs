using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAnimation : MonoBehaviour
{
    public GameObject[] Objects;
    public bool IsAnimated = false;
    public float Target, timer, velocity = 1.0f;
    public bool Regressive;
    
    void Start()
    {
        Objects = SceneObjects.GetObjectsOnScene().AllObjects;
        OpenSceneAnimation();
    }

    void OnGameFinish()
    {
        CloseSceneAnimation();
    }

    public void OpenSceneAnimation()
    {
        timer = 0.0f;
        Target = 1.0f;
        IsAnimated = true;
    }

    public void CloseSceneAnimation()
    {
        timer = 1.0f;
        Target = 0.0f;
        Regressive = true;
        IsAnimated = true;
    }

    void FixedUpdate()
    {
        if(IsAnimated == true)
        {
            if(Regressive == true)
            {
                timer = timer - (Time.deltaTime * velocity);

                SetScale(new Vector3(timer, timer, timer));

                if(timer <= Target)
                {
                    SetScale(new Vector3(Target, Target, Target));
                    IsAnimated = false;
                }
            }else{
                timer = timer + (Time.deltaTime * velocity);

                SetScale(new Vector3(timer, timer, timer));

                if(timer >= Target)
                {
                    SetScale(new Vector3(Target, Target, Target));
                    IsAnimated = false;
                }
            }
        }
    }

    public void SetScale(Vector3 ScaleValue)
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            Objects[i].transform.localScale = ScaleValue;
        }
    }
}