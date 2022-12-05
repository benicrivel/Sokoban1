using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControls : MonoBehaviour
{
    public void OpenScene(string SceneToOpen){
        SceneManager.LoadScene(SceneToOpen);
    }

    public void EnableObject(GameObject ObjectToOpen)
    {
        ObjectToOpen.SetActive(true);
    }
    
    public void DisableObject(GameObject ObjectToClose)
    {
        //StartCoroutine("WaitToDisable", ObjectToClose);
    }

    IEnumerator WaitToDisable(GameObject ObjectToClose)
    {
        yield return new WaitForSeconds(1);
        ObjectToClose.SetActive(false);
    }
}
