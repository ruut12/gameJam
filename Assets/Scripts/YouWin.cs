using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("you_win");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
