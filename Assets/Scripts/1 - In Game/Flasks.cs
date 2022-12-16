using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flasks : MonoBehaviour
{
    public int typeOfFlask;

    public GameObject flaskCollider;
/*
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Toxic")
        {
            Debug.Log("2");
        }
        Debug.Log("Stay");
        switch (typeOfFlask)
        {
            case 1: //direita
                Instantiate(flaskCollider, transform.parent);
                Instantiate(flaskCollider, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), transform.rotation);
                Instantiate(flaskCollider, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), transform.rotation);
                Instantiate(flaskCollider, new Vector3(transform.position.x + 3, transform.position.y, transform.position.z), transform.rotation);
                Instantiate(flaskCollider, new Vector3(transform.position.x + 4, transform.position.y, transform.position.z), transform.rotation);
                break;
            case 2: //esquerda
                Instantiate(flaskCollider, transform.parent);
                Instantiate(flaskCollider, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), transform.rotation);
                Instantiate(flaskCollider, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), transform.rotation);
                Instantiate(flaskCollider, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), transform.rotation);
                Instantiate(flaskCollider, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 1), transform.rotation);
                Instantiate(flaskCollider, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z - 1), transform.rotation);
                break;
            case 3: //esquerda
                Instantiate(flaskCollider, transform.parent);
                Instantiate(flaskCollider, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), transform.rotation);
                break;
            case 4: //esquerda
                Instantiate(flaskCollider, transform.parent);
                Instantiate(flaskCollider, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), transform.rotation);
                Instantiate(flaskCollider, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), transform.rotation);
                break;
        }
    }*/

    public void DestroyThis()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Toxic")
        {
            Debug.Log("3");
        }
        if (collision.gameObject.tag == "Toxic")
        {
            Debug.Log("Spawn");
            string dir = collision.gameObject.name;
            Debug.Log("" + dir);
            DropTheBomb();
            switch (typeOfFlask)
            {
                case 1:
                    if(dir == "Right")
                    {
                        Instantiate(flaskCollider, new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x + 1.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x + 2.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x + 3.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x + 4.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x + 5.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x + 6.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x + 7.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x + 8.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x + 9.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x + 10.7f, transform.position.y, transform.position.z), transform.rotation);
                        DestroyThis();
                    }
                    else if (dir == "Down")
                    {
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 1.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 2.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 3.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 4.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 5.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 6.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 7.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 8.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 9.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 10.7f, transform.position.y, transform.position.z), transform.rotation);
                        DestroyThis();
                    }
                    else if (dir == "Left")
                    {
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 1.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 2.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 3.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 4.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 5.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 6.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 7.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 8.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 9.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 10.7f, transform.position.y, transform.position.z), transform.rotation);
                        DestroyThis();
                    }
                    else if (dir == "Up")
                    {
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 1.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 2.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 3.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 4.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 5.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 6.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 7.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 8.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 9.7f, transform.position.y, transform.position.z), transform.rotation);
                        Instantiate(flaskCollider, new Vector3(transform.position.x - 10.7f, transform.position.y, transform.position.z), transform.rotation);
                        DestroyThis();
                    }
                    else
                    {
                        Debug.Log("deu ruim");
                    }

                    break;
                case 2:
                    Instantiate(flaskCollider, new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(flaskCollider, new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z + 1), transform.rotation);
                    Instantiate(flaskCollider, new Vector3(transform.position.x - 0.3f, transform.position.y, transform.position.z - 1), transform.rotation);
                    Instantiate(flaskCollider, new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(flaskCollider, new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z + 1), transform.rotation);
                    Instantiate(flaskCollider, new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z - 1), transform.rotation);
                    Instantiate(flaskCollider, new Vector3(transform.position.x + 1.7f, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(flaskCollider, new Vector3(transform.position.x + 1.7f, transform.position.y, transform.position.z + 1), transform.rotation);
                    Instantiate(flaskCollider, new Vector3(transform.position.x + 1.7f, transform.position.y, transform.position.z - 1), transform.rotation);
                    DestroyThis();
                    break;
                case 3: //esquerda
                    Instantiate(flaskCollider, new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(flaskCollider, new Vector3(transform.position.x - 1.7f, transform.position.y, transform.position.z), transform.rotation);
                    DestroyThis();
                    break;
                case 4: //esquerda
                    Instantiate(flaskCollider, new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(flaskCollider, new Vector3(transform.position.x - 1.7f, transform.position.y, transform.position.z), transform.rotation);
                    Instantiate(flaskCollider, new Vector3(transform.position.x - 2.7f, transform.position.y, transform.position.z), transform.rotation);
                    DestroyThis();
                    break;
            }
        }
    }

    public void DropTheBomb()
    {
        
    }
}
