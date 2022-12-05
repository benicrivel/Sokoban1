using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorZ : MonoBehaviour
{
    bool isMoving, PlayertLeft;
    Vector3 FinalPosition, UpPosition, DownPosition;
    GameObject Player; 

    void Start()
    {
        Player = SceneObjects.GetObjectsOnScene().Player;
        UpPosition = transform.position + new Vector3(0,1,0);
        DownPosition = transform.position;

        //UndoMove(UpPosition);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPosition = Player.transform.position;

        if(PlayerPosition.x != transform.position.x || PlayerPosition.z != transform.position.z){
            PlayertLeft = true;
        }

        if(PlayertLeft == true){
            if(PlayerPosition.x == transform.position.x && PlayerPosition.z == transform.position.z){
                
                Vector3 Delta, ElevatorDestination, PlayerDestination;
                float PlayerRotation;

                if(FinalPosition == UpPosition){
                    Delta = new Vector3(0, -1, 0);
                    ElevatorDestination = DownPosition;
                }
                else{
                    Delta = new Vector3(0, 1, 0);
                    ElevatorDestination = UpPosition;
                }

                PlayerRotation = Player.transform.eulerAngles.y;
                PlayerDestination = Player.transform.position + Delta;

                if(isMoving == false){
                    Player.GetComponent<Player>().MoveAndSave(PlayerDestination);
                    MoveAndSave(ElevatorDestination);
                }

                PlayertLeft = false;
            }   
        }

        if(isMoving == true){
            transform.position = Vector3.MoveTowards(transform.position, FinalPosition, 5.0f * Time.deltaTime);
            
            if(transform.position == FinalPosition){
                isMoving = false;
            }
        }
    }

    public void MoveAndSave(Vector3 Destination){
        StartCoroutine("WaitToSavePosition", transform.position);
        FinalPosition = Destination;
        isMoving = true;
    }

    public void UndoMove(Vector3 Destination){
        FinalPosition = Destination;
        isMoving = true;
    }

    IEnumerator WaitToSavePosition(Vector3 PositionToSave)
    {
        yield return new WaitForSeconds(0.1f);
        UndoSystem.SavePosition(gameObject, PositionToSave, 0.0f, false);
    }
}