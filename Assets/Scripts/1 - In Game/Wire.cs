using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public Wire[] Wires;
    public ElevatorX[] Xelevators;
    bool Switch = true;
    bool Active = false;

    public void SetActive(bool WireActive)
    {
        Active = WireActive;

        if(Wires.Length > 0){
            for(int i = 0; i < Wires.Length; i++)
            {
                if(Wires[i].transform.gameObject){
                    Wires[i].SetActive(Active);                    
                }
            }
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
