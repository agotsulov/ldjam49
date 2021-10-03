using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject backGround;
    public float bgStep = 0.00000001f;

    public float scale = 0.5f;



    private Rigidbody2D rb;

    private Vector3 startPoint;
    private Vector3 endPoint;

    private Vector3 targetPoint;
    private Vector3 swipe;
    private Vector3 direction;
    private float lenght;

    public float maxLenght;

    public bool onGround;

    public List<GameObject> playerPrefabs;

    private GameObject currentChild;

    private Vector3 bgPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("Update1Sec", 0.0f, 1.0f);

        ChangeForm(0);
    }

    void Update1Sec()
    {
        float r = Random.Range(0.0f, 1.0f);

        if ((0.49 > r) && (r < 0.5f))
        {
            int idx = (int)Random.Range(0.0f, playerPrefabs.Count);
            ChangeForm(idx);
        }

    }

    void Update()
    {
        bgPos = backGround.transform.localPosition;
        bgPos.y = -bgStep * transform.position.y;
        backGround.transform.localPosition = bgPos;

        if (Input.GetButtonDown("Fire1"))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 1;
        }
        if (Input.GetButton("Fire1"))
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 1;

            swipe = endPoint - startPoint;

            lenght = swipe.magnitude;
            direction = swipe.normalized;

            // targetPoint = transform.position + direction * lenght * scale;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            if (onGround)
            {
                rb.velocity = direction * lenght * scale;
            }
        }

        if (transform.position.y < -10.0f)
        {
            SceneManager.LoadScene("SampleScene");
        }

    }


    void ChangeForm(int i)
    {
        Destroy(currentChild);
        GameObject newForm = Instantiate(playerPrefabs[i], transform.position, transform.rotation);
        newForm.transform.parent = transform;
        currentChild = newForm;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
}
