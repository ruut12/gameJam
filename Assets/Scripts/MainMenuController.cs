using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    public GameState gamePlay;
    public int players, readyPlayers;
    public Text nrPlayers, playerOne, playerTwo, playerThree, playerFour, mainInfo, player1Ready, player2Ready, player3Ready, player4Ready;
    public Image p1Img, p2Img, p3Img, p4Img;
    public int p1ReadyPress = 0;
    public int p2ReadyPress = 0;
    public int p3ReadyPress = 0;
    public int p4ReadyPress = 0;
    public string[,] chars = new string[7, 2] { { "char1", "-" }, { "char2", "-" } , { "char3", "-" } , { "char4", "-" } , { "char5", "-" }, { "char6", "-" }, { "char7", "-" }};
	// Use this for initialization
	void Start () {
        p1Img = GameObject.Find("Player1Img").GetComponent<Image>();
        p2Img = GameObject.Find("Player2Img").GetComponent<Image>();
        p3Img = GameObject.Find("Player3Img").GetComponent<Image>();
        p4Img = GameObject.Find("Player4Img").GetComponent<Image>();
        mainInfo = GameObject.Find("PressAorX").GetComponent<Text>();
        nrPlayers = GameObject.Find("PlayerAmount").GetComponent<Text>();
        playerOne = GameObject.Find("Player1Con").GetComponent<Text>();
        playerTwo = GameObject.Find("Player2Con").GetComponent<Text>();
        playerThree = GameObject.Find("Player3Con").GetComponent<Text>();
        playerFour = GameObject.Find("Player4Con").GetComponent<Text>();
        player1Ready = GameObject.Find("Player1Ready").GetComponent<Text>();
        player2Ready = GameObject.Find("Player2Ready").GetComponent<Text>();
        player3Ready = GameObject.Find("Player3Ready").GetComponent<Text>();
        player4Ready = GameObject.Find("Player4Ready").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown("joystick 1 button 0") && p1ReadyPress == 0)
        {
            mainInfo.text = "Press B or X to get ready";
            playerOne.text = "Player 1";
            p1Img.sprite = Resources.Load<Sprite>(chars[0,0]);
            player1Ready.text = "Not ready";
            p1ReadyPress = 1;
            players++;
        }
        if (Input.GetKeyDown("joystick 1 button 1") && p1ReadyPress == 1)
        {
            player1Ready.text = "Ready";
            p1ReadyPress = 2;
            readyPlayers++;
        }
            if (Input.GetKeyDown("joystick 2 button 0") && p2ReadyPress == 0)
        {
            mainInfo.text = "Press B or X to get ready";
            playerTwo.text = "Player 2";
            p2Img.sprite = Resources.Load<Sprite>(chars[1, 0]);
            player2Ready.text = "Not ready";
            p2ReadyPress = 1;
            players++;
        }
        if (Input.GetKeyDown("joystick 2 button 1") && p2ReadyPress == 1)
        {
            player2Ready.text = "Ready";
            p2ReadyPress = 2;
            readyPlayers++;
        }
        if (Input.GetKeyDown("joystick 3 button 0") && p3ReadyPress == 0)
        {
            mainInfo.text = "Press B or X to get ready";
            playerThree.text = "Player 3";
            p3Img.sprite = Resources.Load<Sprite>(chars[2, 0]);
            player3Ready.text = "Not ready";
            p3ReadyPress = 1;
            players++;
        }
        if (Input.GetKeyDown("joystick 3 button 1") && p3ReadyPress == 1)
        {
            player3Ready.text = "Ready";
            p3ReadyPress = 2;
            readyPlayers++;
        }
        if (Input.GetKeyDown("joystick 4 button 0") && p4ReadyPress == 0)
        {
            mainInfo.text = "Press B or X to get ready";
            playerFour.text = "Player 4";
            p4Img.sprite = Resources.Load<Sprite>(chars[3, 0]);
            player4Ready.text = "Not ready";
            p4ReadyPress = 1;
            players++;
        }
        if (Input.GetKeyDown("joystick 4 button 1") && p4ReadyPress == 1)
        {
            player4Ready.text = "Ready";
            p4ReadyPress = 2;
            readyPlayers++;
        }

        Debug.Log(readyPlayers);

        if(players == readyPlayers && readyPlayers > 1) {
            gamePlay.startGame();
        }
    }
}
