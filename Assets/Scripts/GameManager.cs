using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int players = 0;
    public static int playersLeft = 0;
    public int gameOver = 0;
    public string winScreenName = "WinScene";
    public static int winner = 0;
	// Use this for initialization
	void Start () {
        GameState.gameSceneLoaded = true;

        if (GameState.p1ReadyPress == 2)
        {
            players++;
        }
        else
        {
            PlayerOneScore.lives = 0;
        }
        if (GameState.p2ReadyPress == 2)
        {
            players++;
        }
        else
        {
            PlayerTwoScore.lives = 0;
        }
        if (GameState.p3ReadyPress == 2)
        {
            players++;
        }
        else
        {
            PlayerThreeScore.lives = 0;
        }
        if (GameState.p4ReadyPress == 2)
        {
            players++;
        }
        else
        {
            PlayerFourScore.lives = 0;
        }

        GameObject.Find("PlayerOne").SetActive(GameState.p1ReadyPress == 2);
        GameObject.Find("PlayerOneScore").SetActive(GameState.p1ReadyPress == 2);
        
        GameObject.Find("PlayerTwo").SetActive(GameState.p2ReadyPress == 2);
        GameObject.Find("PlayerTwoScore").SetActive(GameState.p2ReadyPress == 2);
        
        GameObject.Find("PlayerThree").SetActive(GameState.p3ReadyPress == 2);
        GameObject.Find("PlayerThreeScore").SetActive(GameState.p3ReadyPress == 2);

        GameObject.Find("PlayerFour").SetActive(GameState.p4ReadyPress == 2);
        GameObject.Find("PlayerFourScore").SetActive(GameState.p4ReadyPress == 2);

        playersLeft = players;
    }
	
	// Update is called once per frame
	void Update () {
		if(playersLeft < 2)
        {
            if(PlayerOneScore.lives > 0)
            {
                winScreenName = "winner_blue";
            }
            if (PlayerTwoScore.lives > 0)
            {
                winScreenName = "winner_green";
            }
            if (PlayerThreeScore.lives > 0)
            {
                winScreenName = "winner_red";
            }
            if (PlayerFourScore.lives > 0)
            {
                winScreenName = "winner_pink";
            }
            SceneManager.LoadScene(winScreenName);
        } 
	}
}
