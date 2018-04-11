using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string PLAYER_ONE = "PlayerOne";
    private const string PLAYER_TWO = "PlayerTwo";
    private const string PLAYER_THREE = "PlayerThree";
    private const string PLAYER_FOUR = "PlayerFour";

    public int players = 0;
    public static int playersLeft = 0;
    public int gameOver = 0;
    public string winScreenName;
    public static int winner = 0;

    void Start()
    {
        GameState.gameSceneLoaded = true;

        if (GameState.p1ReadyPress == 2)
        {
            players++;
        }
        else
        {
            GameObject.Find(PLAYER_ONE).GetComponent<PlayerScore>().SetLivesZero();
        }
        if (GameState.p2ReadyPress == 2)
        {
            players++;
        }
        else
        {
            GameObject.Find(PLAYER_TWO).GetComponent<PlayerScore>().SetLivesZero();
        }
        if (GameState.p3ReadyPress == 2)
        {
            players++;
        }
        else
        {
            GameObject.Find(PLAYER_THREE).GetComponent<PlayerScore>().SetLivesZero();
        }
        if (GameState.p4ReadyPress == 2)
        {
            players++;
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

        playersLeft = players;
    }

    // Update is called once per frame
    void Update()
    {
        if (playersLeft < 2)
        {
            if (GameObject.Find(PLAYER_ONE) != null && GameObject.Find(PLAYER_ONE).GetComponent<PlayerScore>().GetLives() > 0)
            {
                winScreenName = "winner_blue";
            }
            else if (GameObject.Find(PLAYER_TWO) != null && GameObject.Find(PLAYER_TWO).GetComponent<PlayerScore>().GetLives() > 0)
            {
                winScreenName = "winner_green";
            }
            else if (GameObject.Find(PLAYER_THREE) != null && GameObject.Find(PLAYER_THREE).GetComponent<PlayerScore>().GetLives() > 0)
            {
                winScreenName = "winner_red";
            }
            else if (GameObject.Find(PLAYER_FOUR) != null && GameObject.Find(PLAYER_FOUR).GetComponent<PlayerScore>().GetLives() > 0)
            {
                winScreenName = "winner_pink";
            }

            if (winScreenName != null)
            {
                SceneManager.LoadScene(winScreenName);
            }
        }
    }
}
