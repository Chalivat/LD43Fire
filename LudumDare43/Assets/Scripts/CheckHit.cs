using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit : MonoBehaviour {

    public PlayerMovement player;
    float damage;
	void Start () {
	}
	

	void Update () {

        if(player.weapon != null)
        {
            if (player.weapon.CompareTag("Baton"))
            {
                damage = 10;
            }
            if (player.weapon.CompareTag("Marteau"))
            {
                damage = 80;
            }
            if (player.weapon.CompareTag("Pelle"))
            {
                damage = 40;
            }
            if (player.weapon.CompareTag("EPE"))
            {
                damage = 25;
            }
        }
        Debug.Log(player.weapon.name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ca collide");
        if (collision.gameObject.CompareTag("Primordial") && collision.gameObject.CompareTag("SecondFire"))
        {
            player.isHittingFire = true;
            player.Light();
        }

        if (collision.gameObject.CompareTag("Ennemy"))
        {
            Debug.Log("Touchay");
            collision.gameObject.GetComponent<Ennemis_Behavior>().KnockBack(damage);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("put1");
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            Debug.Log("Touchay");
            collision.gameObject.GetComponent<Ennemis_Behavior>().KnockBack(-damage);
        }
    }
}
