using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d2;
    // Use this for initialization
    void Start()
    {
        rb2d2 = GameObject.Find("PlayerTwo").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Store the current vertical input in the float moveVertical.
        if (rb2d2 != null)
        {
            float moveHorizontal2 = Input.GetAxis("xbox2hor");
            if (Input.GetKeyDown("joystick 2 button 0"))
            {
                rb2d2.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }
            Vector2 movement2 = new Vector2(moveHorizontal2, 0);
            rb2d2.AddForce(movement2 * speed);
        }
    }
}
