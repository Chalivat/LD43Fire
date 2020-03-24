using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;
    private GameObject target;
    private bool Triggered;
    private float distance;
    private PlayerMovement PlayerScript;
    public bool snapped;
    float time;
    public bool isHolding;
    public SpriteRenderer sp;
    private PrimordialFire_Behavior fire;

	void Start () {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        fire = GameObject.FindGameObjectWithTag("fire").GetComponent<PrimordialFire_Behavior>();
        target = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = target.GetComponent<PlayerMovement>();
        if (!gameObject.CompareTag("Baton"))
        {
            fire.isWeapon = true;
        }
    }

	void Update () {
        if (isHolding)
        {
            Debug.Log(gameObject.name + " Is held");
        }
        distance = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y).magnitude;
        if (Triggered && snapped && PlayerScript.weapon == null)
        {
            rb.velocity = (new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y) * speed);
        }

        if (PlayerScript.weapon != null)
        {
            Triggered = false;
        }
        if (distance <= 1 && snapped && PlayerScript.weapon == null)
        {
            isHolding = true;
            sp.enabled = false;
        }
        if (isHolding)
        {
            transform.position = (target.gameObject.transform.position);
            PlayerScript.isHolding = true;
            PlayerScript.weapon = gameObject;
        }
        if (!snapped)
        {
            Wait();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerScript.weapon == null)
        {
            Triggered = true;
        }

        if (collision.CompareTag("Primordial") && !collision.CompareTag("Baton") && !isHolding)
        {
            Destroy(gameObject);
        }
        
    }

    private void Wait()
    {
        time += Time.deltaTime;
        if (time >=2)
        {
            snapped = true;
        }
    }

    public void Drop(Vector2 direction)
    {
        rb.AddForce(direction * 5,ForceMode2D.Impulse);
        snapped = false;
        Triggered = false;
        time = 0;
        isHolding = false;
    }

    private void OnDestroy()
    {
        if (!gameObject.CompareTag("Baton"))
        {
            fire.isWeapon = false;
        }
        
    }
}
