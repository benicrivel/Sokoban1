using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField]
    private BoxCollider col;

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
        StartCoroutine("TurnOffCollider");
        //BoxMove();
    }

    IEnumerator TurnOffCollider()
    {
        col.enabled = false;
        yield return new WaitForSeconds(2f);
        col.enabled = true;
    }

    public void MoveAndSave(Vector3 Direction)
    {
        FinalPosition = transform.position + Direction;
        StartCoroutine("WaitToSavePosition", transform.position);
        //BoxMove();
    }

    public void TeleportAndSave(Vector3 Direction)
    {
        FinalPosition = Direction;
        StartCoroutine("WaitToSavePosition", transform.position);
    }

    IEnumerator WaitToSavePosition(Vector3 PositionToSave)
    {
        yield return new WaitForSeconds(0.1f);
        UndoSystem.SavePosition(gameObject, PositionToSave, 0.0f, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("TP1"))
        {
            Vector3 n3 = GameObject.FindGameObjectWithTag("TP1A").transform.position;
            TeleportAndSave(new Vector3(n3.x, n3.y+1, n3.z));
            StartCoroutine("TurnOffCollider");
        }

        if (other.gameObject.tag == ("TP1A"))
        {
            Vector3 n3 = GameObject.FindGameObjectWithTag("TP1").transform.position;
            TeleportAndSave(new Vector3(n3.x, n3.y + 1, n3.z));
            StartCoroutine("TurnOffCollider");
        }

        if (other.gameObject.tag == ("TP2"))
        {
            Vector3 n3 = GameObject.FindGameObjectWithTag("TP2A").transform.position;
            TeleportAndSave(new Vector3(n3.x, n3.y + 1, n3.z));
            StartCoroutine("TurnOffCollider");
        }

        if (other.gameObject.tag == ("TP2A"))
        {
            Vector3 n3 = GameObject.FindGameObjectWithTag("TP2").transform.position;
            TeleportAndSave(new Vector3(n3.x, n3.y + 1, n3.z));
            StartCoroutine("TurnOffCollider");
        }
        if (other.gameObject.tag == ("TP3"))
        {
            Vector3 n3 = GameObject.FindGameObjectWithTag("TP3A").transform.position;
            TeleportAndSave(new Vector3(n3.x, n3.y + 1, n3.z));
            StartCoroutine("TurnOffCollider");
        }

        if (other.gameObject.tag == ("TP3A"))
        {
            Vector3 n3 = GameObject.FindGameObjectWithTag("TP3").transform.position;
            TeleportAndSave(new Vector3(n3.x, n3.y + 1, n3.z));
            StartCoroutine("TurnOffCollider");
        }
        if (other.gameObject.tag == ("TP4"))
        {
            Vector3 n3 = GameObject.FindGameObjectWithTag("TP4A").transform.position;
            TeleportAndSave(new Vector3(n3.x, n3.y + 1, n3.z));
            StartCoroutine("TurnOffCollider");
        }

        if (other.gameObject.tag == ("TP4A"))
        {
            Vector3 n3 = GameObject.FindGameObjectWithTag("TP4").transform.position;
            TeleportAndSave(new Vector3(n3.x, n3.y + 1, n3.z));
            StartCoroutine("TurnOffCollider");
        }
    }
}
