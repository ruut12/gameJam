using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {
    public Scene game, menu;
    public string gameSceneName = "4 players";
    public string gameMenuName = "LarsScene";
    public GameObject levelOne, mainMenu;
    public int playerCount;
	// Use this for initialization
	void Start () {
        game = SceneManager.GetSceneByName(gameSceneName);
        menu = SceneManager.GetSceneByName(gameMenuName);
        SceneManager.SetActiveScene(menu);
    }

    public void startGame()
    {
        int p1ReadyPress = GameObject.Find("MainMenu").GetComponent<MainMenuController>().p1ReadyPress;
        int p2ReadyPress = GameObject.Find("MainMenu").GetComponent<MainMenuController>().p2ReadyPress;
        int p3ReadyPress = GameObject.Find("MainMenu").GetComponent<MainMenuController>().p3ReadyPress;
        int p4ReadyPress = GameObject.Find("MainMenu").GetComponent<MainMenuController>().p4ReadyPress;
        SceneManager.SetActiveScene(game);
        if(p1ReadyPress == 0)
        {
            GameObject.Find("PlayerOne").SetActive(false);
            GameObject.Find("PlayerOneScore").SetActive(false);
        }
        if (p2ReadyPress == 0)
        {
            GameObject.Find("PlayerTwo").SetActive(false);
            GameObject.Find("PlayerTwoScore").SetActive(false);
        }
        if (p3ReadyPress == 0)
        {
            GameObject.Find("PlayerThree").SetActive(false);
            GameObject.Find("PlayerThreeScore").SetActive(false);
        }
        if (p4ReadyPress == 0)
        {
            GameObject.Find("PlayerFour").SetActive(false);
            GameObject.Find("PlayerFourScore").SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
