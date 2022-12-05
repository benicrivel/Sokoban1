using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerMovement
{
    public static MoveStep[] moveSteps = new MoveStep[0];

    public struct MoveStep
    {
        public bool SavePosition;
        public Vector3 Direction;
        public float Rotation;
    }

    public static void Restart(){
        MoveStep[] moveSteps = new MoveStep[0];
    }

    public static MoveStep GetMove()
    {
        return moveSteps[0];
    }

    public static void AddMoveStep(Vector3 Direction, float Rotation)
    {
        MoveStep[] aux = moveSteps;

        moveSteps = new MoveStep[moveSteps.Length + 1];

        for (int i = 0; i < aux.Length; i++)
        {
            moveSteps[i] = aux[i];
        }

        moveSteps[moveSteps.Length - 1].Direction = Direction;
        moveSteps[moveSteps.Length - 1].Rotation = Rotation;
    }

    public static void DeleteMoveStep()
    {
        MoveStep[] aux = moveSteps;

        moveSteps = new MoveStep[moveSteps.Length - 1];

        for (int i = 0; i < (aux.Length - 1); i++)
        {
            moveSteps[i] = aux[i + 1];
        }
    }
}

