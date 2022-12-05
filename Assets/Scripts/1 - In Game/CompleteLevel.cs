using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Steamworks;

public class CompleteLevel : MonoBehaviour
{
    public bool NextLevelCalled, GameCompleted, GameStarted;
    
    public delegate void OnGameFinish();
    public static OnGameFinish onGameFinish;

    void Update()
    {
        GameObject[] Targets = SceneObjects.GetObjectsOnScene().Targets;
        GameCompleted = true;

        for (int i = 0; i < Targets.Length; i++){
            if (Targets[i].GetComponent<Target>().OnTarget == false){
                GameCompleted = false;
            }
        }

        if (GameCompleted == true && NextLevelCalled == false)
        {
            /*if (!SteamManager.Initialized) { return; }

            Steamworks.SteamUserStats.SetAchievement("test");
            Steamworks.SteamUserStats.StoreStats();
            */
            onGameFinish?.Invoke();
            CallNextLevel();
            NextLevelCalled = true;
        }
    }

    void CallNextLevel()
    {
        int CurrentLevel = SaveSystem.LoadValue.CurrentLevel();
        int nextlevel = CurrentLevel + 1;
        
        if(nextlevel < 50)
        {
            SaveSystem.SaveValue.LevelToOpen(nextlevel);
            SaveSystem.SaveValue.MaximumLevel(nextlevel);

            GetComponent<SceneAnimation>().CloseSceneAnimation();
            StartCoroutine("WaitToLoadScene", "Level");
        }
        else
        {
            //Create congratulations scene and put on string replacing "Menu" to "Congratulations"
            GetComponent<SceneAnimation>().CloseSceneAnimation();
            StartCoroutine("WaitToLoadScene", "Menu");
        }
    }

    IEnumerator WaitToLoadScene(string SceneToOpen)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneToOpen);
    }
}
