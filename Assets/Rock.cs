using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    public GameObject followObject;
    public float distance;

    private Vector3 pos;


    void Update()
    {
        if (Vector3.Distance(transform.position, followObject.transform.position) > distance)
        {
            pos = transform.position;
            pos.x = followObject.transform.position.x;
            transform.position = pos;
        }
    }
}
