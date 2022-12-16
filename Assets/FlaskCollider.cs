using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider");
        if (other.gameObject.tag == "Toxic")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collider");
        if (other.gameObject.tag == "Toxic")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
