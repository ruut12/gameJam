using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput3 : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
		Vector2 directionalInput = new Vector2(Input.GetAxisRaw("horizontal3"), 0);
        player.SetDirectionalInput(directionalInput);

        if (Input.GetButtonDown("Jump3"))
        {
            player.OnJumpInputDown();
        }

        if (Input.GetButtonUp("Jump3"))
        {
            player.OnJumpInputUp();
        }
    }
}
