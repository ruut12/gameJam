using UnityEngine;

[RequireComponent(typeof(Player))]
public class ForcePush : MonoBehaviour
{
    public string fireButtonName;
    public GameObject pushAnimation;

    public float radius = 3;
    public float power = 1000;
    public float PushCooldown = 1;
    public float UpliftMultiplier = 3.0F;
    public bool canPush = true;

    long lasActionTime;
    float pushingAnimTimer = 0;
    float pushingAnimCd = 0.3f;

    void Start()
    {

    }

    void FixedUpdate()
    {
        var nowTicks = System.DateTime.Now.Ticks;

        if ((lasActionTime + (PushCooldown * 10000000)) < (nowTicks))
        {
            canPush = true;
            lasActionTime = nowTicks; // alusta tegemist
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