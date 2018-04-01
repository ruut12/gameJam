using UnityEngine;

public class ForcePush2 : MonoBehaviour {

	public float radius;
	public float power;
	public float PushCooldown = 3.0f;
	public float UpliftMultiplier = 3.0F;

	long lasActionTime;
	public bool canPush = true;

    float pushingAnimTimer = 0;
    float pushingAnimCd = 0.3f;

    void Start()
	{

	}

	void FixedUpdate ()
	{
		var nowTicks = System.DateTime.Now.Ticks;

		if ((lasActionTime + (PushCooldown * 10000000)) < (nowTicks)) {
			canPush = true;
			lasActionTime = nowTicks; // alusta tegemist
            FindObjectOfType<AudioManager>().Play("push");
            gameObject.GetComponent<Player>().pushing = true;
            pushingAnimTimer = pushingAnimCd;
        }

        if (Input.GetButtonDown("Fire2")) {
			if (canPush) {
				pushItems ();
				canPush = false;
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

    void pushItems(){
		FindObjectOfType<AudioManager>().Play("push");

		Vector3 explosionPos = transform.position;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);

		foreach (Collider2D hit in colliders) {
			if (hit && hit.GetComponent<Rigidbody2D>())
				hit.GetComponent<Rigidbody2D>().AddExplosionForce(power, explosionPos, radius, UpliftMultiplier);

		}	
	}
}