﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTwoScore : MonoBehaviour
{

    public int lives = 3;
    public int deathTime = 3;
    public Text LivesText;
    public PlayerInput2 PlayerRigid;

    float damagedAnimTimer = 0;
    float damagedAnimCd = 0.3f;

    void Start()
    {
        LivesText = GameObject.Find("PlayerTwoScore").GetComponent<Text>();
        PlayerRigid = GameObject.Find("PlayerTwo").GetComponent<PlayerInput2>();

        LivesText.text = "" + lives;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DangerCollider")
        {
            Debug.Log("Collision detected");
            FindObjectOfType<AudioManager>().Play("damage");
            lives -= 1;
            gameObject.GetComponent<Player>().damaged = true;
            damagedAnimTimer = damagedAnimCd;
        }

        if (lives < 1)
        {
            Destroy(PlayerRigid);
            gameObject.GetComponent<Player>().moveSpeed = 0;
            Invoke("DestroyObject", deathTime);
            FindObjectOfType<AudioManager>().Play("death");
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (LivesText != null)
        {
            LivesText.text = "" + lives;
        }

        if (gameObject.GetComponent<Player>().damaged)
        {
            if (damagedAnimTimer > 0)
            {
                damagedAnimTimer -= Time.deltaTime;
            }
            else
            {
                gameObject.GetComponent<Player>().damaged = false;
            }
        }
    }
}
