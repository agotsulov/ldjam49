using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoving : MonoBehaviour
{
    private GameObject followObject;
    private float distance = 18;
    private float d2 = 14;
    private float d3 = 13;

    private Vector3 generationOffset = new Vector3(80f, 120f, 10f);

    private Vector3 pos;

    private Vector3 rotateAxis = new Vector3(0, 0, 1f);

    void Start()
    {
        followObject = GameObject.Find("Player");
        InvokeRepeating("UpdatePos", 0.0f, 2.0f);
    }


    void UpdatePos()
    {
        if (Vector3.Distance(transform.position, followObject.transform.position) > distance)
        {
            pos.x = followObject.transform.position.x + Random.Range(-generationOffset.x, generationOffset.x);
            pos.y = followObject.transform.position.y + Random.Range(-generationOffset.y, generationOffset.y);
            pos.z = Random.Range(1.0f, generationOffset.z);

            if (Vector3.Distance(pos, followObject.transform.position) < d2)
            {

                Vector3 swipe = pos - followObject.transform.position;

                Vector3 direction = swipe.normalized;

                pos += direction * d3;
            }

            transform.position = pos;

            transform.RotateAround(transform.position, rotateAxis, Random.Range(0f, 180f));
        }
    }


}
