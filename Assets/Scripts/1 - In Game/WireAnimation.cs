using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireAnimation : MonoBehaviour
{
    public GameObject Light;
    public Vector3[] LightPositions;
    int LightStep = 0;

    public void StartAnimation()
    {
        GameObject OBJ = Instantiate(Light, transform.position, transform.rotation);
        //OBJ.GetComponent<WireLight>().Positions = LightPositions;
    }
}
