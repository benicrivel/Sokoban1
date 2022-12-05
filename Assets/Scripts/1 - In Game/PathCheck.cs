using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCheck : MonoBehaviour
{
    public bool PushObjects, WalkOnFloor, WalkOnTarget, WalkOnBox, WalkOnEnergyBox, WalkOnZelevator, WalkOnXelevator, WalkOnActiveFloor, WalkOnWire, WalkOnSwitch;
    SceneObjects.ObjectsOnScene sceneObjects;

    private void Start()
    {
        sceneObjects = SceneObjects.GetObjectsOnScene();
    }

    public bool CheckPathIsPossible(Vector3 Direction)
    {
        Vector3 Destination = transform.position + Direction;
        
        if(CheckPath(Destination) == true){
            GameObject ObjectOnPath = CheckIsGameObjectOnPath(Destination);

            if(ObjectOnPath == null){
                return true;
            }
            else{
                if(PushObjects == true) {
                    if(ObjectOnPath.GetComponent<PathCheck>().CheckPathIsPossible(Direction) == true){
                        ObjectOnPath.GetComponent<BoxMovement>().MoveAndSave(Direction);
                        return true;
                    }
                    else{
                        //Debug.Log("Path Isn't Possible");
                        return false;
                    }
                }
                else{
                    //Debug.Log("Can't Push Objects");
                    return false;
                }
            }
        }
        else{
            //Debug.Log("Path isn't exit");
            return false;
        }
    }

    public GameObject CheckIsGameObjectOnPath(Vector3 Destination)
    {
        GameObject obj = null;

        for (int i = 0; i < sceneObjects.AllObjects.Length; i++)
        {
            float Distance = Vector3.Distance(Destination, sceneObjects.AllObjects[i].transform.position);
            if (Distance < 0.1f){
                obj = sceneObjects.AllObjects[i];
            }
        }

        return obj;
    }

    bool CheckPath(Vector3 Destination)
    {
        Destination = Destination + new Vector3(0,-1,0);
        bool PathIsPossible = false;
        
        if(WalkOnFloor == true){PathIsPossible = CheckObjectsOnList(Destination, sceneObjects.Floors);}
        if(WalkOnTarget == true && PathIsPossible == false){PathIsPossible = CheckObjectsOnList(Destination, sceneObjects.Targets);}
        if(WalkOnBox == true && PathIsPossible == false){PathIsPossible = CheckObjectsOnList(Destination, sceneObjects.Boxes);}
        if(WalkOnEnergyBox == true && PathIsPossible == false){PathIsPossible = CheckObjectsOnList(Destination, sceneObjects.EnergyBoxes);}
        if(WalkOnZelevator == true && PathIsPossible == false){PathIsPossible = CheckObjectsOnList(Destination, sceneObjects.Zelevators);}
        if(WalkOnXelevator == true && PathIsPossible == false){PathIsPossible = CheckObjectsOnList(Destination, sceneObjects.Xelevators);}
        if(WalkOnActiveFloor == true && PathIsPossible == false){PathIsPossible = CheckObjectsOnList(Destination, sceneObjects.ActivatorFloors);}
        if(WalkOnWire == true && PathIsPossible == false){PathIsPossible = CheckObjectsOnList(Destination, sceneObjects.Wires);}
        if(WalkOnSwitch == true && PathIsPossible == false){PathIsPossible = CheckObjectsOnList(Destination, sceneObjects.Switches);}

        return PathIsPossible;
    }

    public bool CheckObjectsOnList(Vector3 Destination, GameObject[] List)
    {
        bool PathIsPossible = false;

        for (int i = 0; i < List.Length; i++){
            float Distance = Vector3.Distance(Destination, List[i].transform.position);
            if (Distance < 0.1f){PathIsPossible = true;}
        }

        return PathIsPossible;
    }
}
