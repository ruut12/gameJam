using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class PlayerScore : MonoBehaviour
{
    public string playerScoreObjectName;

    public int lives = 3;

    public Text LivesText;
    public int deathTime = 3;
    public PlayerInput PlayerRigid;
    public GameObject blood;

    float damagedAnimTimer = 0;
    float damagedAnimTime = 0.3f;

    float hitCooldownTimer = 0;
    float hitCooldownTime = 1;

    void Start()
    {
        var score = GameObject.Find(playerScoreObjectName);
        if (score != null)
        {
            LivesText = score.GetComponent<Text>();
        }

        PlayerRigid = gameObject.GetComponent<PlayerInput>();

        if (LivesText != null)
        {
            LivesText.text = "" + lives;
        }
    }

    public void SetLivesZero()
    {
        lives = 0;
    }

    public int GetLives()
    {
        return lives;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitCooldownTimer == 0)
        {
            if (collision.gameObject.tag == "DangerCollider")
            {
                Debug.Log("Collision detected");

                hitCooldownTimer = hitCooldownTime;
                lives -= 1;

                if (lives > 0)
                {
                    gameObject.GetComponent<Player>().damaged = true;
                    damagedAnimTimer = damagedAnimTime;
                    FindObjectOfType<AudioManager>().Play("damage");
                }

                Instantiate(blood, transform.position, Quaternion.identity);
            }
        }

        if (lives < 1 && !gameObject.GetComponent<Player>().dead)
        {
            //Instantiate (blood, transform.position, Quaternion.identity);
            Debug.Log("game over");
            gameObject.GetComponent<Player>().moveSpeed = 0;
            gameObject.GetComponent<Player>().dead = true;
            FindObjectOfType<AudioManager>().Play("death");
            Destroy(PlayerRigid);
            Invoke("DestroyObject", deathTime);
            Camera.main.GetComponent<CameraShake>().shakecamera();

        }
    }


    void DestroyObject()
    {
        Destroy(gameObject);
        GameManager.playersLeft--;
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

        if (hitCooldownTimer > 0)
        {
            hitCooldownTimer -= Time.deltaTime;
        }
        else if (hitCooldownTimer < 0)
        {
            hitCooldownTimer = 0;
        }
    }
}
