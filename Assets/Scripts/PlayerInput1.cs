using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput1 : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
		Vector2 directionalInput = new Vector2(Input.GetAxisRaw("horizontal1"), 0);
        player.SetDirectionalInput(directionalInput);

        if (Input.GetButtonDown("Jump1"))
        {
            player.OnJumpInputDown();
        }

        if (Input.GetButtonUp("Jump1"))
        {
            player.OnJumpInputUp();
        }
    }
}
