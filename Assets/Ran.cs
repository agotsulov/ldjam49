using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ran : MonoBehaviour
{

    private float distance = 18;
    private GameObject followObject;
    public List<GameObject> prefabs;

    private Vector3 generationOffset = new Vector3(1f, 1f, 10f);

    private Vector3 pos;

    private Vector3 rotateAxis = new Vector3(0, 0, 1f);

    private GameObject currentChild;
    // Start is called before the first frame update
    void Start()
    {

        followObject = GameObject.Find("Player");
        InvokeRepeating("UpdateForm", 0.0f, 5.0f);
    }

    void ChangeForm(int i)
    {
        Destroy(currentChild);

        pos.x = transform.position.x + Random.Range(-generationOffset.x, generationOffset.x);
        pos.y = transform.position.y + Random.Range(-generationOffset.y, generationOffset.y);
        pos.z = Random.Range(1.0f, generationOffset.z);


        GameObject newForm = Instantiate(prefabs[i], pos, transform.rotation);
        newForm.transform.parent = transform;

        newForm.transform.RotateAround(transform.position, rotateAxis, Random.Range(0f, 180f));

        currentChild = newForm;
    }

    void UpdateForm()
    {
        if (Vector3.Distance(transform.position, followObject.transform.position) > distance)
        {
            int idx = (int)Random.Range(0.0f, prefabs.Count);
            ChangeForm(idx);
        }
    }
}
