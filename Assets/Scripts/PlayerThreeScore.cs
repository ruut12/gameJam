using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerThreeScore : MonoBehaviour
{

    public int lives = 3;
    public Text LivesText;
    public int deathTime = 3;
    public PlayerInput3 PlayerRigid;
    // Use this for initialization
    void Start()
    {
        LivesText = GameObject.Find("PlayerThreeScore").GetComponent<Text>();
        PlayerRigid = GameObject.Find("PlayerThree").GetComponent<PlayerInput3>();

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
        }
        if (lives < 1)
        {
            Destroy(PlayerRigid);
            Invoke("DestroyObject", deathTime);
            FindObjectOfType<AudioManager>().Play("death");
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.text = "" + lives;
    }
}
