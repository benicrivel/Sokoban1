using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public float speed;
    public float height;
    public GameObject maincamera;
    public float newY;
    public bool b, x2;
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        maincamera = GameObject.FindGameObjectWithTag("MainCamera");

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.localPosition;
        newY = Mathf.Sin(Time.time * speed);
        transform.localPosition = new Vector3(pos.x, height + newY, pos.z);

        Vector3 Target = new Vector3(maincamera.transform.position.x, transform.position.y, maincamera.transform.position.z);
        transform.LookAt(Target);
    }
}
