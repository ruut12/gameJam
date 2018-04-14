using UnityEngine;
using UnityEngine.SceneManagement;

public class restartAnykey : MonoBehaviour
{
    string gameMenuName = "PlayerSelect";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            print("any key pressed");

            SceneManager.LoadScene(gameMenuName);
        }
    }
}
