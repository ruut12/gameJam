using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOneScore : MonoBehaviour {

    public int lives = 3;
    public Text LivesText;
    public PlayerInput1 PlayerRigid;
	// Use this for initialization
	void Start () {
		LivesText = GameObject.Find("PlayerOneScore").GetComponent<Text>();
        PlayerRigid = GameObject.Find("PlayerOne").GetComponent<PlayerInput1>();

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
            //FindObjectOfType<AudioManager>().Play("damage");
            lives -= 1;
        }
        if (lives < 1)
        {
            Destroy(PlayerRigid);
            Invoke("DestroyObject", 5);
            //FindObjectOfType<AudioManager>().Play("death");
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
        LivesText.text = "" + lives;
	}
}
