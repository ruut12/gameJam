using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTwoScore : MonoBehaviour
{

    public static int lives = 3;
    public int deathTime = 3;
    public Text LivesText;
    public PlayerInput2 PlayerRigid;
	public GameObject blood;

    float damagedAnimTimer = 0;
    float damagedAnimCd = 0.3f;

    bool hitCooldown;
    float hitTimer = 0;

    void Start()
    {
        var score = GameObject.Find("PlayerTwoScore");
        if(score != null)
        {
            LivesText = score.GetComponent<Text>();
        }

        PlayerRigid = GameObject.Find("PlayerTwo").GetComponent<PlayerInput2>();

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
                hitCooldown = true;
				Instantiate (blood, transform.position, Quaternion.identity);
            }
        }

        if (lives < 1)
        {
			//Instantiate (blood, transform.position, Quaternion.identity);
			Destroy(PlayerRigid);
            gameObject.GetComponent<Player>().moveSpeed = 0;
            Invoke("DestroyObject", deathTime);
            FindObjectOfType<AudioManager>().Play("death");
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
