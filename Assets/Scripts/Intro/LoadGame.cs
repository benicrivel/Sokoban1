using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class LoadGame : MonoBehaviour
{
    public string SceneToOpen;
    public bool DeleteSaveGame;
    public RenderPipelineAsset[] QualityLevels;
    
    // Start is called before the first frame update
    public void Start()
    {
        if(DeleteSaveGame == true){
            SaveSystem.SaveGameBase.DeleteSaveGameBase();
        }

        if(SaveSystem.SaveGameBase.CkeckSaveGameBaseIsCreated() == false){
            SaveSystem.SaveGameBase.CreateSaveGameBase();
        }

        SetQualityLevel(SaveSystem.LoadValue.Graphics());
        SceneManager.LoadScene(SceneToOpen);
    }

    public void SetQualityLevel(int a)
    {
        QualitySettings.SetQualityLevel(a);
        QualitySettings.renderPipeline = QualityLevels[a];
    }
}
