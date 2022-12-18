using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSource : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 5f *-1, Color.red);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward *-1, out hit, 5f))
        {
            //print($"colidiu {hit.transform.name} no ponto {hit.point}");
            Debug.Log(hit.collider.name);
            if(hit.collider.name == "Box(Clone)")
            {
                Debug.Log("Sussexo");
            }
        }
    }
}
