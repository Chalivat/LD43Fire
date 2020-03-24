using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemis_Behavior : MonoBehaviour {

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private GameObject fire;
    private GameObject player;
    public float stop;
    public float speed;
    private float distance;

    public Sprite face;
    public Sprite back;
    public Sprite right;
    public Sprite left;
    private Vector2 latePosition;
    private Vector2 newPosition;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        fire = GameObject.FindGameObjectWithTag("Primordial");
        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	void Update () {
        newPosition = transform.position;
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 difference = latePosition - newPosition;

        if (Vector2.Distance(transform.position, fire.transform.position) > stop)
        {
           // transform.position = Vector2.MoveTowards(transform.position, fire.transform.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, fire.transform.position) <= stop)
        {
           // transform.position = this.transform.position;
        }

        if(difference.x > 0 && difference.x > difference.y)
        {
            sr.sprite = left;
        }
        if (difference.x < 0 && difference.x < difference.y)
        {
            sr.sprite = right;
            
        }
        if (difference.y > 0 && difference.y > difference.x)
        {
            sr.sprite = face;
        }
        if (difference.y < 0 && difference.y < difference.x)
        {
            sr.sprite = back;
        }

        latePosition = newPosition;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Primordial") || collision.gameObject.CompareTag("SecondFire"))
        {
            Debug.Log("COOOOOOLISIONNNNN");
            Destroy(gameObject);
        }
    }*/

    public void KnockBack(float force)
    {
        rb.AddForce(new Vector2( player.gameObject.transform.position.x  - transform.position.x, player.gameObject.transform.position.y - transform.position.y ) * force, ForceMode2D.Impulse);
        Debug.Log("aie");
    }
    
}
