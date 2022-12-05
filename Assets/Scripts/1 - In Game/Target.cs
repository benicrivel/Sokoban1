using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool OnTarget;
    GameObject[] Boxes;
    // Start is called before the first frame update
    void Start()
    {
         Boxes = SceneObjects.GetObjectsOnScene().Boxes;
    }

    // Update is called once per frame
    void Update()
    {
        OnTarget = false;

        for (int i = 0; i < Boxes.Length; i++)
        {
            if (Boxes[i].transform.position.x == transform.position.x && Boxes[i].transform.position.z == transform.position.z)
            {
                OnTarget = true;
            }
        }
    }
}
