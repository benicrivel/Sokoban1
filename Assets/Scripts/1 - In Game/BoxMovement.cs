using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public Vector3 FinalPosition;
    // Start is called before the first frame update
    void Start()
    {
        FinalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, FinalPosition, 5.0f * Time.deltaTime);
    }
    /*
    void BoxMove()
    {
        Debug.Log("box entrou");
        for(int i = 0; i == 5000; i++)
        {
            Debug.Log("entrou");
            transform.position = Vector3.MoveTowards(transform.position, FinalPosition, 5.0f * Time.deltaTime);
            if (transform.position == FinalPosition)
            {
                i = 5000;
            }
        }
    }*/

    public void UndoMove(Vector3 Destination)
    {
        FinalPosition = Destination;
        //BoxMove();
    }

    public void MoveAndSave(Vector3 Direction)
    {
        FinalPosition = transform.position + Direction;
        StartCoroutine("WaitToSavePosition", transform.position);
        //BoxMove();
    }

    IEnumerator WaitToSavePosition(Vector3 PositionToSave)
    {
        yield return new WaitForSeconds(0.1f);
        UndoSystem.SavePosition(gameObject, PositionToSave, 0.0f, false);
    }
}
