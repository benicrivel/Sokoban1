using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    [SerializeField]
    private Transform playerT;
    Player p;

    private void Start()
    {
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnBack()
    {
        int StepLength = UndoSystem.Steps.Length;

        if (StepLength > 0)
        {
            UndoSystem.Step previousStep = UndoSystem.previousStep();

            GameObject[] Objects = previousStep.Objects;
            Vector3[] Positions = previousStep.Positions;
            float[] Rotations = previousStep.Rotations;

            for (int i = 0; i < Objects.Length; i++)
            {
                if (Objects[i].transform.tag == "Player")
                {
                    Objects[i].GetComponent<Player>().UndoMove(Positions[i]);
                }
                if (Objects[i].transform.tag == "Box" || Objects[i].transform.tag == "Energy Box")
                {
                    Objects[i].GetComponent<BoxMovement>().UndoMove(Positions[i]);
                }
                if (Objects[i].transform.tag == "ElevatorZ")
                {
                    Objects[i].GetComponent<ElevatorZ>().UndoMove(Positions[i]);
                }
            }

            UndoSystem.DeleteStep();
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 Input = value.Get<Vector2>();
        Vector2 InputControl = new Vector2((float)Mathf.RoundToInt(Input.y), (float)Mathf.RoundToInt(Input.x));
        InputControl = new Vector2(-Input.y, Input.x);

        if (InputControl.y > 0.9f)
        {
            Vector3 Delta = new Vector3(1, 0, 0);
            float Rot = 90.0f;

            PlayerMovement.AddMoveStep(Delta, Rot);


            //p.LookUp();
        }
        else
        {
            if (InputControl.x > 0.9f)
            {
                Vector3 Delta = new Vector3(0, 0, -1);
                float Rot = 180.0f;

                PlayerMovement.AddMoveStep(Delta, Rot);

                //p.LookRight();

                playerT.rotation = new Quaternion(0, 0, 0, 0);
            }
            else
            {
                if (InputControl.y < -0.9f)
                {
                    Vector3 Delta = new Vector3(-1, 0, 0);
                    float Rot = 270.0f;

                    PlayerMovement.AddMoveStep(Delta, Rot);

                    //p.LookDown();

                    playerT.rotation = new Quaternion(0, 90, 0, 0);
                }
                else
                {
                    if (InputControl.x < -0.9f)
                    {
                        Vector3 Delta = new Vector3(0, 0, 1);
                        float Rot = 0.0f;

                        PlayerMovement.AddMoveStep(Delta, Rot);

                        //p.LookLeft();

                        p.transform.rotation = new Quaternion(0, 180, 0, 0);
                    }
                }
            }
        }
    }
}
