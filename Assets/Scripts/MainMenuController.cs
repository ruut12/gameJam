using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    public GameState gamePlay;
    public int players, readyPlayers;
    public Text mainInfo, player1Ready, player2Ready, player3Ready, player4Ready;
    public int p1ReadyPress = 0;
    public int p2ReadyPress = 0;
    public int p3ReadyPress = 0;
    public int p4ReadyPress = 0;
    public GameObject p1Img, p2Img, p3Img, p4Img;
    public string[,] chars = new string[4, 2] { { "char1", "-" }, { "char2", "-" } , { "char3", "-" } , { "char4", "-" }};
	// Use this for initialization
	void Start () {
        p1Img = GameObject.Find("Player1Img");
        p2Img = GameObject.Find("Player2Img");
        p3Img = GameObject.Find("Player3Img");
        p4Img = GameObject.Find("Player4Img");
        p1Img.SetActive(false);
        p2Img.SetActive(false);
        p3Img.SetActive(false);
        p4Img.SetActive(false);
        mainInfo = GameObject.Find("PressAorX").GetComponent<Text>();
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
            p1Img.SetActive(true);
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
            p2Img.SetActive(true);
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
            p3Img.SetActive(true);
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
            p4Img.SetActive(true);
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

        if(players == readyPlayers && readyPlayers > 1) {
            gamePlay.startGame(p1ReadyPress, p2ReadyPress, p3ReadyPress, p4ReadyPress);
        }
    }
}
