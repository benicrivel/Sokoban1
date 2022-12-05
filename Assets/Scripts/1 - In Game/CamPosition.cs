using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Objects;
    public GameObject CameraObject;
    void Start()
    {        
        Objects = SceneObjects.GetObjectsOnScene().AllObjects;

        float xmin = 10000;
        float zmin = 10000;
        float xmax = -10000;
        float zmax = -10000;

        for (int i = 0; i < Objects.Length; i++)
        {
            if(Objects[i].transform.position.x > xmax)
            {
                xmax = Objects[i].transform.position.x;
            }

            if (Objects[i].transform.position.x < xmin)
            {
                xmin = Objects[i].transform.position.x;
            }

            if (Objects[i].transform.position.z > zmax)
            {
                zmax = Objects[i].transform.position.z;
            }

            if (Objects[i].transform.position.x < zmin)
            {
                zmin = Objects[i].transform.position.x;
            }
        }

        CameraObject.transform.position = new Vector3((xmax + xmin) / 2, 0.0f, (zmax + zmin) / 2);        
    }
}
