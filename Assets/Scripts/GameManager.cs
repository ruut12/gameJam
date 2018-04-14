using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string PLAYER_ONE = "PlayerOne";
    private const string PLAYER_TWO = "PlayerTwo";
    private const string PLAYER_THREE = "PlayerThree";
    private const string PLAYER_FOUR = "PlayerFour";

    public List<string> players = new List<string>();
    public List<string> deadPlayers = new List<string>();
    public int gameOver = 0;
    public static int winner = 0;

    void Start()
    {
        GameState.gameSceneLoaded = true;

        if (GameState.p1ReadyPress == 2)
        {
            players.Add(PLAYER_ONE);
        }
        else
        {
            GameObject.Find(PLAYER_ONE).GetComponent<PlayerScore>().SetLivesZero();
        }
        if (GameState.p2ReadyPress == 2)
        {
            players.Add(PLAYER_TWO);
        }
        else
        {
            GameObject.Find(PLAYER_TWO).GetComponent<PlayerScore>().SetLivesZero();
        }
        if (GameState.p3ReadyPress == 2)
        {
            players.Add(PLAYER_THREE);
        }
        else
        {
            GameObject.Find(PLAYER_THREE).GetComponent<PlayerScore>().SetLivesZero();
        }
        if (GameState.p4ReadyPress == 2)
        {
            players.Add(PLAYER_FOUR);
        }
        else
        {
            GameObject.Find(PLAYER_FOUR).GetComponent<PlayerScore>().SetLivesZero();
        }

        GameObject.Find(PLAYER_ONE).SetActive(GameState.p1ReadyPress == 2);
        GameObject.Find("PlayerOneScore").SetActive(GameState.p1ReadyPress == 2);

        GameObject.Find(PLAYER_TWO).SetActive(GameState.p2ReadyPress == 2);
        GameObject.Find("PlayerTwoScore").SetActive(GameState.p2ReadyPress == 2);

        GameObject.Find(PLAYER_THREE).SetActive(GameState.p3ReadyPress == 2);
        GameObject.Find("PlayerThreeScore").SetActive(GameState.p3ReadyPress == 2);

        GameObject.Find(PLAYER_FOUR).SetActive(GameState.p4ReadyPress == 2);
        GameObject.Find("PlayerFourScore").SetActive(GameState.p4ReadyPress == 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (players.Count < 2)
        {
            string playerAlive;
            string winScreenName = null;

            if (players.Count > 0)
            {
                playerAlive = players[0];
            }
            else
            {
                playerAlive = deadPlayers[deadPlayers.Count - 1];
            }

            switch (playerAlive)
            {
                case PLAYER_ONE:
                    winScreenName = "winner_blue";
                    break;
                case PLAYER_TWO:
                    winScreenName = "winner_green";
                    break;
                case PLAYER_THREE:
                    winScreenName = "winner_red";
                    break;
                case PLAYER_FOUR:
                    winScreenName = "winner_pink";
                    break;
            }

            SceneManager.LoadScene(winScreenName);
        }
    }

    internal void RemovePlayer(string name)
    {
        if (players.Contains(name))
        {
            players.Remove(name);
            deadPlayers.Add(name);
        }
    }
}
