using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorX : MonoBehaviour
{
    public bool invert, Active;
    GameObject[] AllObjects = new GameObject[0];
    bool isMoving;
    Vector3 FinalPosition, UpPosition, DownPosition;

    void Start()
    {
        UpPosition = transform.position + new Vector3(0, 1, 0);
        DownPosition = transform.position;
        DesactiveElevator();
    }

    private void Update()
    {
        if(AllObjects.Length == 0){
            AllObjects = SceneObjects.GetObjectsOnScene().AllObjects;
        }

        if(isMoving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, FinalPosition, 5.0f * Time.deltaTime);

            if(transform.position == FinalPosition){
                isMoving = false;
            }
        }
    }

    public void ActiveElevator()
    {
        if(invert == true){
            FinalPosition = UpPosition;
        }
        else{
            FinalPosition = DownPosition;
        }

        CheckObjectOnTop();
        isMoving = true;
        Active = true;
    }

    public void DesactiveElevator()
    {
        if(invert == true){
            FinalPosition = DownPosition;
        }
        else{
            FinalPosition = UpPosition;
        }

        CheckObjectOnTop();
        isMoving = true;
        Active = false;
    }

    void CheckObjectOnTop()
    {
        Debug.Log("Checking Object On Top");

        GameObject ObjectOnTop = null;

        for(int i = 0; i < AllObjects.Length; i++)
        {
            float Distance = Vector3.Distance(AllObjects[i].transform.position, transform.position + new Vector3(0, 1, 0));

            if(Distance < 0.1f)
            {
                ObjectOnTop = AllObjects[i];
            }
        }

        if(ObjectOnTop != null)
        {
            if (ObjectOnTop.transform.tag == "Player")
            {
                ObjectOnTop.GetComponent<Player>().MoveAndSave(FinalPosition + new Vector3(0, 1, 0));
            }
            if (ObjectOnTop.transform.tag == "Box" || ObjectOnTop.transform.tag == "Energy Box")
            {
                ObjectOnTop.GetComponent<BoxMovement>().MoveAndSave(FinalPosition + new Vector3(0, 1, 0));
            }
        }
    }
}
