using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireLight : MonoBehaviour
{
    public Vector3[] LightPositions;
    int LightStep = 0;

    // Update is called once per frame
    void Update()
    {
        /*if(LightStep < LightPositions.Length)
        {
            Light.transform.localPosition = Vector3.MoveTowards(Light.transform.localPosition, LightPositions[LightStep], 3.0f * Time.deltaTime);

            if(Light.transform.localPosition == LightPositions[LightStep])
            {
                LightStep++;
            }
        }*/

        if(LightStep == LightPositions.Length)
        {
            Destroy(gameObject);
        }        
    }
}
