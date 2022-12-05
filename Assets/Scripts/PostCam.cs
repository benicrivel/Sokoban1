using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PostCam : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (FileBasedPrefs.GetInt("Post Processing") == 1)
        {
            GetComponent<UniversalAdditionalCameraData>().renderPostProcessing = true;
        }
        else
        {
            GetComponent<UniversalAdditionalCameraData>().renderPostProcessing = false;
        }
    }
}
