using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput4 : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
		Vector2 directionalInput = new Vector2(Input.GetAxisRaw("horizontal4"), 0);
        player.SetDirectionalInput(directionalInput);

        if (Input.GetButtonDown("Jump4"))
        {
            player.OnJumpInputDown();
        }

        if (Input.GetButtonUp("Jump4"))
        {
            player.OnJumpInputUp();
        }
    }
}
