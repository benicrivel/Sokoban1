using UnityEngine;

public static class SceneObjects
{
    public static ObjectsOnScene sceneObjects;

    public struct ObjectsOnScene{
        public GameObject[] AllObjects;
        public GameObject Player;
        public GameObject[] Boxes, EnergyBoxes, Floors, ElevatorFloors, ActivatorFloors, Wires, Switches, Targets, Zelevators, Xelevators;
    }

    static string[] GameTags = {"Player", "Box", "Energy Box", "Floor","Elevator Floor", "Activator Floor", "Wire", "Switch", "Target", "Elevator", "Elevator X", "Flasc"};

    public static ObjectsOnScene GetObjectsOnScene(){return sceneObjects;}

    public static void Restart(){
        RestartData();
        CalculateAllObjects();
    }

    static void RestartData(){
        sceneObjects.Player = GameObject.FindWithTag(GameTags[0]);

        sceneObjects.Boxes = GameObject.FindGameObjectsWithTag(GameTags[1]);
        sceneObjects.EnergyBoxes = GameObject.FindGameObjectsWithTag(GameTags[2]);

        sceneObjects.Floors = GameObject.FindGameObjectsWithTag(GameTags[3]);
        sceneObjects.ElevatorFloors = GameObject.FindGameObjectsWithTag(GameTags[4]);
        sceneObjects.ActivatorFloors = GameObject.FindGameObjectsWithTag(GameTags[5]);

        sceneObjects.Wires = GameObject.FindGameObjectsWithTag(GameTags[6]);
        sceneObjects.Switches = GameObject.FindGameObjectsWithTag(GameTags[7]);

        sceneObjects.Targets = GameObject.FindGameObjectsWithTag(GameTags[8]);

        sceneObjects.Zelevators = GameObject.FindGameObjectsWithTag(GameTags[9]);
        sceneObjects.Xelevators = GameObject.FindGameObjectsWithTag(GameTags[10]);
    }

    static void CalculateAllObjects()
    {
        sceneObjects.AllObjects = new GameObject[0];
        sceneObjects.AllObjects = ArrayMath.AddGameObject(sceneObjects.AllObjects, GameObject.FindWithTag(GameTags[0]));

        for(int i = 1; i < GameTags.Length; i++)
        {
            sceneObjects.AllObjects = ArrayMath.AddGameObjects(sceneObjects.AllObjects, GameObject.FindGameObjectsWithTag(GameTags[i]));
        }
    }
}
