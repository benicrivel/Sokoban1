using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReflector : MonoBehaviour
{
    public bool isL;

    public Collider up;
    public Collider right;
    public Collider down;
    public Collider left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isL)
        {
            //if laser comes left then laser up
            //if laser comes up then laser left
            //if laser comes down then laser right
            //if laser comes right then laser down
        }
        else if (!isL)
        {
            //if laser comes left then laser down
            //if laser comes down then laser left
            //if laser comes right then laser up
            //if laser comes up then laser right
        }
    }
}
