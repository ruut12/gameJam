using UnityEngine;

[RequireComponent(typeof(Player))]
public class ForcePushEffector2D : MonoBehaviour
{
    public string fireButtonName;
    public GameObject pushAnimation;
    
    public float pushingAnimTime = 0.6f;
    float pushingAnimTimer = 0;

    public float pushCooldownTime = 0.6f;
    float pushCooldownTimer = 0;


    public float effectorTime = 0.1f;
    float effectorTimer = 0;


    private PointEffector2D effector;

    void Start()
    {
        effector = GetComponent<PointEffector2D>();
        effector.enabled = false;
    }

    void FixedUpdate()
    {
        var nowTicks = System.DateTime.Now.Ticks;
        
        if (Input.GetButtonDown(fireButtonName))
        {
            if (pushCooldownTimer == 0 && gameObject.GetComponent<PlayerScore>().GetLives() > 0)
            {
                //pushItems();
                effector.enabled = true;
                
                FindObjectOfType<AudioManager>().Play("push");
                gameObject.GetComponent<Player>().pushing = true;
                pushingAnimTimer = pushingAnimTime;
                Instantiate(pushAnimation, transform.position, Quaternion.identity);
                pushCooldownTimer = pushCooldownTime;
                effectorTimer = effectorTime;
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

            if (effectorTimer > 0)
            {
                effectorTimer -= Time.deltaTime;
            } else
            {
                effector.enabled = false;
                effectorTimer = 0;
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