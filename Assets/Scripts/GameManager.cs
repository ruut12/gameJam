using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameState.gameSceneLoaded = true;

        GameObject.Find("PlayerOne").SetActive(GameState.p1ReadyPress == 2);
        GameObject.Find("PlayerOneScore").SetActive(GameState.p1ReadyPress == 2);
        
        GameObject.Find("PlayerTwo").SetActive(GameState.p2ReadyPress == 2);
        GameObject.Find("PlayerTwoScore").SetActive(GameState.p2ReadyPress == 2);
        
        GameObject.Find("PlayerThree").SetActive(GameState.p3ReadyPress == 2);
        GameObject.Find("PlayerThreeScore").SetActive(GameState.p3ReadyPress == 2);

        GameObject.Find("PlayerFour").SetActive(GameState.p4ReadyPress == 2);
        GameObject.Find("PlayerFourScore").SetActive(GameState.p4ReadyPress == 2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
