using UnityEngine;

[RequireComponent(typeof(Player))]
public class ForcePushEffector2D : MonoBehaviour
{
    public string fireButtonName;
    public GameObject pushAnimation;

    bool canPush = true;

    float pushingAnimTimer = 0;
    float pushingAnimCd = 0.6f;

    public float pushCooldownTime = 0.6f;

    float pushCooldownTimer = 0;

    private PointEffector2D effector;

    void Start()
    {
        effector = GetComponent<PointEffector2D>();
        effector.enabled = !effector.enabled;
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
                //pushItems();
                effector.enabled = !effector.enabled;

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

    //void pushItems()
    //{
    //    Vector3 explosionPos = transform.position;
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);

    //    foreach (Collider2D hit in colliders)
    //    {
    //        if (hit && hit.GetComponent<Rigidbody2D>())
    //            hit.GetComponent<Rigidbody2D>().AddExplosionForce(power, explosionPos, radius, UpliftMultiplier);

    //    }
    //}
}