using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeuDetect : MonoBehaviour {

    private PlayerMovement playerScript;
    public CircleCollider2D circle;
    public GameObject black;
    public GameObject grey;

    void Start () {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
	}

	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CheckIt"))
        {
            if (playerScript.asHit && playerScript.weapon.name == "Baton" || playerScript.weapon.CompareTag("Baton"))
            {
                playerScript.Light();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            Debug.Log("COOOOOOLISIONNNNN");
            Destroy(collision.gameObject);

            circle.radius += 2f;
            black.transform.localScale += new Vector3(2f , 2f, 0);
            grey.transform.localScale += new Vector3(2 , 2f , 0);
        }
    }
}
