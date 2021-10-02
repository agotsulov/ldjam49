using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followObject;
    public Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = followObject.transform.position + distance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followObject.transform.position + distance;
    }
}
