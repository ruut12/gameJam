using UnityEngine;

[RequireComponent(typeof(Player))]
public class ForcePush : MonoBehaviour
{
    public string fireButtonName;
    public GameObject pushAnimation;

    public float radius = 3;
    public float power = 1000;
    public float UpliftMultiplier = 3.0F;
    public float pushCooldownTime = 0.6f;

    bool canPush = true;

    float pushingAnimTimer = 0;
    float pushingAnimCd = 0.6f;

    float pushCooldownTimer = 0;

    void Start()
    {

    }

    void FixedUpdate()
    {
        var nowTicks = System.DateTime.Now.Ticks;

        if (pushCooldownTimer == 0)
        {
            canPush = true;
        }

        if (Input.GetButtonDown(fireButtonName))
        {
            if (canPush && gameObject.GetComponent<PlayerScore>().GetLives() > 0)
            {
                pushItems();
                canPush = false;
                FindObjectOfType<AudioManager>().Play("push");
                gameObject.GetComponent<Player>().pushing = true;
                pushingAnimTimer = pushingAnimCd;
                Instantiate(pushAnimation, transform.position, Quaternion.identity);
                pushCooldownTimer = pushCooldownTime;
            }
        }
    }

    private void Update()
    {
        if (gameObject.GetComponent<Player>().pushing)
        {
            if (pushingAnimTimer > 0)
            {
                pushingAnimTimer -= Time.deltaTime;
            }
            else
            {
                gameObject.GetComponent<Player>().pushing = false;
            }

            if (pushCooldownTimer > 0)
            {
                pushCooldownTimer -= Time.deltaTime;
            }
            else
            {
                pushCooldownTimer = 0;
            }
        }
    }

    void pushItems()
    {
        Vector3 explosionPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);

        foreach (Collider2D hit in colliders)
        {
            if (hit && hit.GetComponent<Rigidbody2D>())
                hit.GetComponent<Rigidbody2D>().AddExplosionForce(power, explosionPos, radius, UpliftMultiplier);

        }
    }
}