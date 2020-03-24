using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torche : MonoBehaviour {

    public bool isLight = false;
    public GameObject feu;
    public GameObject fire;
	void Start () {
        feu.SetActive(false);
	}
	

	void Update () {

        if (isLight)
        {
            feu.SetActive(true);
        }
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((collision.CompareTag("Marteau") || collision.CompareTag("Pelle")) && isLight) && (!collision.GetComponent<Items>().isHolding && !gameObject.GetComponent<Items>().isHolding) && gameObject.GetComponent<Items>().snapped)
        {
            Destroy(collision.gameObject);
            Instantiate(fire, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
