using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorFloor : MonoBehaviour
{
    public WireAnimation[] WiresAnimations;
    public ElevatorX[] Xelevators;
    GameObject[] EnergyBoxes = new GameObject[0];
    bool Active = true;
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EnergyBoxes.Length == 0)
            EnergyBoxes = SceneObjects.GetObjectsOnScene().EnergyBoxes;

        CheckEnergyBox();

        if(Active == true)
        {
            timer = timer + Time.deltaTime;

            if(timer > 1.0f)
            {
                for(int i = 0; i < WiresAnimations.Length; i++)
                {
                    WiresAnimations[i].StartAnimation();
                }
                timer = 0.0f;
            }
        }
        else
        {
            timer = 1.0f;
        }
    }

    public void CheckEnergyBox()
    {
        Vector3 Position = transform.position + new Vector3(0, 1, 0);
        Active = false;

        for (int i = 0; i < EnergyBoxes.Length; i++){
            float Distance = Vector3.Distance(Position, EnergyBoxes[i].transform.position);
            if (Distance < 0.1f){Active = true;}
        }

        if(Xelevators.Length > 0)
        {
            if(Active == true)
            {
                for(int i = 0; i < Xelevators.Length; i++)
                {
                    if(Xelevators[i].Active == false){
                        Xelevators[i].ActiveElevator();
                    }
                }
            }
            else
            {
                for(int i = 0; i < Xelevators.Length; i++)
                {
                    if(Xelevators[i].Active == true){
                        Xelevators[i].DesactiveElevator();
                    }
                }
            }
        }
    }
}
