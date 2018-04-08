using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFourController : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d4;

    // Use this for initialization
    void Start()
    {
        rb2d4 = GameObject.Find("PlayerFour").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb2d4 != null)
        {
            float moveHorizontal4 = Input.GetAxis("xbox4hor");
            if (Input.GetKeyDown("joystick 4 button 0"))
            {
                rb2d4.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }
            Vector2 movement4 = new Vector2(moveHorizontal4, 0);
            rb2d4.AddForce(movement4 * speed);
        }

    }
}
