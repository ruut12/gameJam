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
            GameObject.Find("PlayerOne").GetComponent<PlayerScore>().SetLivesZero();
        }
        if (GameState.p2ReadyPress == 2)
        {
            players++;
        }
        else
        {
            GameObject.Find("PlayerTwo").GetComponent<PlayerScore>().SetLivesZero();
        }
        if (GameState.p3ReadyPress == 2)
        {
            players++;
        }
        else
        {
            GameObject.Find("PlayerThree").GetComponent<PlayerScore>().SetLivesZero();
        }
        if (GameState.p4ReadyPress == 2)
        {
            players++;
        }
        else
        {
            GameObject.Find("PlayerFour").GetComponent<PlayerScore>().SetLivesZero();
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
            if(GameObject.Find("PlayerOne") != null && GameObject.Find("PlayerOne").GetComponent<PlayerScore>().GetLives() > 0)
            {
                winScreenName = "winner_blue";
            }
            if (GameObject.Find("PlayerTwo") != null && GameObject.Find("PlayerTwo").GetComponent<PlayerScore>().GetLives() > 0)
            {
                winScreenName = "winner_green";
            }
            if (GameObject.Find("PlayerThree") != null && GameObject.Find("PlayerThree").GetComponent<PlayerScore>().GetLives() > 0)
            {
                winScreenName = "winner_red";
            }
            if (GameObject.Find("PlayerFour") != null && GameObject.Find("PlayerFour").GetComponent<PlayerScore>().GetLives() > 0)
            {
                winScreenName = "winner_pink";
            }
            SceneManager.LoadScene(winScreenName);
        } 
	}
}
