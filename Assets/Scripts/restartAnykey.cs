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
            //Application.LoadLevel("PlayerSelect");
            Scene scene = SceneManager.GetActiveScene();

            SceneManager.LoadScene(gameMenuName);

            if (scene != null)
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }
    }
}
