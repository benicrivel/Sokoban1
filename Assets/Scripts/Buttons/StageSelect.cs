using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public int stage;
    public string name;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetStage(int a)
    {
        stage = a;
        SceneManager.LoadScene(name);
    }
}
