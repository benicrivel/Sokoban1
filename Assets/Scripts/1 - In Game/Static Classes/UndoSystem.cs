using UnityEngine;

public static class UndoSystem
{
    public static Step[] Steps = new Step[0];

    public struct Step
    {
        public GameObject[] Objects;
        public Vector3[] Positions;
        public float[] Rotations;
    }

    public static void Restart()
    {
        Step[] Steps = new Step[0];
    }

    public static void SavePosition(GameObject Object, Vector3 Position, float Rotation, bool NewStep)
    {
        if(NewStep == true){
            AddNewStep(Object, Position, Rotation);
        }
        else{
            IncreaseStep(Object, Position, Rotation);
        }

    }

    static void AddNewStep(GameObject Object, Vector3 Position, float Rotation){
        Step[] aux = Steps;

        Steps = new Step[Steps.Length + 1];

        for(int i = 0; i < aux.Length; i++)
        {
            Steps[i] = aux[i];
        }

        Steps[Steps.Length - 1].Objects = new GameObject[1];
        Steps[Steps.Length - 1].Positions = new Vector3[1];
        Steps[Steps.Length - 1].Rotations = new float[1];

        Steps[Steps.Length - 1].Objects[0] = Object;
        Steps[Steps.Length - 1].Positions[0] = Position;
        Steps[Steps.Length - 1].Rotations[0] = Rotation;
    }

    static void IncreaseStep(GameObject Object, Vector3 Position, float Rotation){
        int ArrayLength = Steps[Steps.Length - 1].Objects.Length;

        GameObject[] auxObjects = Steps[Steps.Length - 1].Objects;
        Vector3[] auxPositions = Steps[Steps.Length - 1].Positions;
        float[] auxRotations = Steps[Steps.Length - 1].Rotations;

        Steps[Steps.Length - 1].Objects = new GameObject[ArrayLength + 1];
        Steps[Steps.Length - 1].Positions = new Vector3[ArrayLength + 1];
        Steps[Steps.Length - 1].Rotations = new float[ArrayLength + 1];

        for(int i = 0; i < ArrayLength; i++)
        {
            Steps[Steps.Length - 1].Objects[i] = auxObjects[i];
            Steps[Steps.Length - 1].Positions[i] = auxPositions[i];
            Steps[Steps.Length - 1].Rotations[i] = auxRotations[i];
        }

        Steps[Steps.Length - 1].Objects[ArrayLength] = Object;
        Steps[Steps.Length - 1].Positions[ArrayLength] = Position;
        Steps[Steps.Length - 1].Rotations[ArrayLength] = Rotation;
    }

    public static Step previousStep()
    {
        return Steps[Steps.Length - 1];
    }

    public static void DeleteStep()
    {
        Step[] aux = Steps;

        Steps = new Step[Steps.Length - 1];

        for (int i = 0; i < (aux.Length - 1); i++)
        {
            Steps[i] = aux[i];
        }
    }
}
