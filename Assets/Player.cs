using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject stick;
    private Vector3 direction = new Vector3(0.0f, -2.0f, 0.0f);

    private Rigidbody2D rb;

    public float speedJumpForce = 1.0f;
    public float jumpForce = 0.0f;

    public bool onGround;

    private Vector3 leftForceR = new Vector3(-0.2f, 0.01f, 0.0f);
    private Vector3 rightForceR = new Vector3(0.2f, 0.01f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = stick.GetComponent<Stick>().onGround;

        if (onGround)
        {

            if ((Input.GetKey(KeyCode.Space)) || (Input.GetKey(KeyCode.UpArrow)))
            {
                Debug.Log("JUMP START");
                jumpForce += speedJumpForce;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log("LEFT");
                rb.AddForce(leftForceR, ForceMode2D.Force);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("RIGHT");
                rb.AddForce(rightForceR, ForceMode2D.Force);
            }
        }

        if ((Input.GetKeyUp(KeyCode.Space)) || (Input.GetKeyUp(KeyCode.UpArrow)))
        {
            Debug.Log("JUMP END");
            rb.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode2D.Force);
            jumpForce = 0.0f;
            // stick.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Force);
            // float speed = 50f;
            // float step = speed * Time.deltaTime;
            // stick.transform.localPosition = Vector3.MoveTowards(stick.transform.localPosition, stick.transform.localPosition + direction, step);
            // stick.transform.localPosition += direction;
        }

        // onGround = false;
        // stick.GetComponent<Stick>().onGround = false;
    }


    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Ground")
    //     {
    //         onGround = true;
    //     }
    // }


    // void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Ground")
    //     {
    //         onGround = false;
    //     }
    // }
}
