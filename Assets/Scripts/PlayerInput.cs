using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    public string jumpButtonName;
    public string horizontalAxisName;

    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw(horizontalAxisName), 0);
        player.SetDirectionalInput(directionalInput);

        if (Input.GetButtonDown(jumpButtonName))
        {
            player.OnJumpInputDown();
        }

        if (Input.GetButtonUp(jumpButtonName))
        {
            player.OnJumpInputUp();
        }
    }
}
