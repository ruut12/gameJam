using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {
    public GameObject levelOne, mainMenu;
    public Button btnStart;
    public int playerCount;
	// Use this for initialization
	void Start () {
        levelOne = GameObject.Find("LevelOne");
        levelOne.SetActive(false);
        mainMenu = GameObject.Find("MainMenu");
        mainMenu.SetActive(true);
        btnStart = GameObject.Find("ButtonStart").GetComponent<Button>();
        btnStart.onClick.AddListener(startGame);

    }

    void startGame()
    {
        playerCount = GameObject.Find("MainMenu").GetComponent<MainMenuController>().players;
        mainMenu.SetActive(false);
        levelOne.SetActive(true);
        if(playerCount == 2)
        {
            GameObject.Find("PlayerThree").SetActive(false);
            GameObject.Find("PlayerThreeScore").SetActive(false);
            GameObject.Find("PlayerFour").SetActive(false);
            GameObject.Find("PlayerFourScore").SetActive(false);
        }
        if (playerCount == 3)
        {
            GameObject.Find("PlayerThree").SetActive(false);
            GameObject.Find("PlayerThreeScore").SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
