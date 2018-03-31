using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    public int players;
    public Text nrPlayers, playerOne, playerTwo, playerThree, playerFour;
    public Image p1Img, p2Img, p3Img, p4Img;
    public int p1Char = 0;
    public int p2Char = 1;
    public int p3Char = 2;
    public int p4Char = 3;
    public string[,] chars = new string[7, 2] { { "char1", "-" }, { "char2", "-" } , { "char3", "-" } , { "char4", "-" } , { "char5", "-" }, { "char6", "-" }, { "char7", "-" }};
	// Use this for initialization
	void Start () {
        p1Img = GameObject.Find("Player1Img").GetComponent<Image>();
        p2Img = GameObject.Find("Player2Img").GetComponent<Image>();
        p3Img = GameObject.Find("Player3Img").GetComponent<Image>();
        p4Img = GameObject.Find("Player4Img").GetComponent<Image>();
        nrPlayers = GameObject.Find("PlayerAmount").GetComponent<Text>();
        playerOne = GameObject.Find("Player1Con").GetComponent<Text>();
        playerTwo = GameObject.Find("Player2Con").GetComponent<Text>();
        playerThree = GameObject.Find("Player3Con").GetComponent<Text>();
        playerFour = GameObject.Find("Player4Con").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown("joystick 1 button 0"))
        {
            playerOne.text = "Player 1";
            p1Img.sprite = Resources.Load<Sprite>(chars[p1Char,0]);
        }
        if (Input.GetKeyDown("joystick 2 button 0"))
        {
            playerTwo.text = "Player 2";
            p2Img.sprite = Resources.Load<Sprite>(chars[1, 0]);
        }
        if (Input.GetKeyDown("joystick 3 button 0"))
        {
            playerThree.text = "Player 3";
            p3Img.sprite = Resources.Load<Sprite>(chars[2, 0]);
        }
        if (Input.GetKeyDown("joystick 4 button 0"))
        {
            playerFour.text = "Player 4";
            p4Img.sprite = Resources.Load<Sprite>(chars[3, 0]);
        }

        nrPlayers.text = "" + players;
    }
}
