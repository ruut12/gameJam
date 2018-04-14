using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public Scene game, menu;
    public string gameSceneName = "4 players";
    public string gameMenuName = "PlayerSelect";
    public int playerCount;
    public static bool gameSceneLoaded;

    public static int p1ReadyPress;
    public static int p2ReadyPress;
    public static int p3ReadyPress;
    public static int p4ReadyPress;


    // Use this for initialization
    void Start()
    {
        menu = SceneManager.GetSceneByName(gameMenuName);
        SceneManager.SetActiveScene(menu);
    }

    public void startGame(int ap1ReadyPress, int ap2ReadyPress, int ap3ReadyPress, int ap4ReadyPress)
    {
        p1ReadyPress = ap1ReadyPress;
        p2ReadyPress = ap2ReadyPress;
        p3ReadyPress = ap3ReadyPress;
        p4ReadyPress = ap4ReadyPress;

        //Debug.Log("startGame");
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(gameSceneName);

        SceneManager.UnloadSceneAsync(scene);
    }

    public void ResetGame()
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(gameMenuName);

        if (scene != null)
        {
            SceneManager.UnloadSceneAsync(scene);
        }
        /*
        game = SceneManager.GetSceneByName(gameSceneName);
        SceneManager.SetActiveScene(game);
     
        Debug.Log("player1" + p1ReadyPress);
        Debug.Log("player2" + p2ReadyPress);
        Debug.Log("player3" + p3ReadyPress);
        Debug.Log("player4" + p4ReadyPress);
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);        

        SceneManager.UnloadSceneAsync(gameMenuName);
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (gameSceneLoaded)
        {
            ResetGame();
            gameSceneLoaded = false;
        }
    }
}
