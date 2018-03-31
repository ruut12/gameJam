using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    public Button btnSubtract, btnAdd;
    public int players;
    public Text nrPlayers;
	// Use this for initialization
	void Start () {
        nrPlayers = GameObject.Find("PlayerAmount").GetComponent<Text>();
        btnSubtract = GameObject.Find("ButtonSubtract").GetComponent<Button>();
        btnSubtract.onClick.AddListener(remPlayers);
        btnAdd = GameObject.Find("ButtonAdd").GetComponent<Button>();
        btnAdd.onClick.AddListener(addPlayers);
    }

    void remPlayers()
    {
        if(players > 2)
        {
            players--;
        }
        
    }
    
    void addPlayers()
    {
        if(players < 4)
        {
            players++;
        }
    }
	
	// Update is called once per frame
	void Update () {
        nrPlayers.text = "" + players;
    }
}
