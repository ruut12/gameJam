using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFourScore : MonoBehaviour
{

    public static int lives = 3;
    public Text LivesText;
    public int deathTime = 3;
    public PlayerInput4 PlayerRigid;

    float damagedAnimTimer = 0;
    float damagedAnimCd = 0.3f;

    bool hitCooldown;
    float hitTimer = 0;

    void Start()
    {
        var score = GameObject.Find("PlayerFourScore");
        if (score != null)
        {
            LivesText = score.GetComponent<Text>();
        }

        PlayerRigid = GameObject.Find("PlayerFour").GetComponent<PlayerInput4>();

        if (LivesText != null)
        {
            LivesText.text = "" + lives;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hitCooldown)
        {
            if (collision.gameObject.tag == "DangerCollider")
            {
                Debug.Log("Collision detected");
                FindObjectOfType<AudioManager>().Play("damage");
                lives -= 1;
                gameObject.GetComponent<Player>().damaged = true;
                damagedAnimTimer = damagedAnimCd;
            }
        }

        if (lives < 1)
        {
            Destroy(PlayerRigid);
            gameObject.GetComponent<Player>().moveSpeed = 0;
            Invoke("DestroyObject", deathTime);
            FindObjectOfType<AudioManager>().Play("death");
            GameManager.playersLeft--;
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

        if (hitCooldown)
        {
            if (hitTimer > 0)
            {
                hitTimer -= Time.deltaTime;
            }
            else
            {
                hitCooldown = false;
            }
        }
    }
}
