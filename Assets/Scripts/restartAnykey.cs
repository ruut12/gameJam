using UnityEngine;
using UnityEngine.SceneManagement;

public class restartAnykey : MonoBehaviour
{
    string gameMenuName = "PlayerSelect";

    float timer = 0;
    float time = 0.7f;

    // Use this for initialization
    void Start()
    {
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
        }

        if (timer == 0 && Input.anyKeyDown)
        {
            print("any key pressed");

            SceneManager.LoadScene(gameMenuName);
        }
    }
}
