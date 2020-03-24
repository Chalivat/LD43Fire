using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimordialFire_Behavior : MonoBehaviour {

    private CircleCollider2D circle;
    public GameObject black;
    public GameObject grey;
    public GameObject[] weapons;
    private int rnd;

    public bool isWeapon = false;
    private float time;

    void Start () {
        circle = transform.GetComponent<CircleCollider2D>();
	}
	
	void Update () {
        /*circle.radius -= 0.01f * Time.deltaTime;
        black.transform.localScale -= new Vector3(0.1f * Time.deltaTime, 0.3f * Time.deltaTime, 0);
        grey.transform.localScale -= new Vector3(0.1f * Time.deltaTime, 0.3f * Time.deltaTime, 0);*/


        if (!isWeapon)
        {
            WeaponSpawn();
        }
    }

    void WeaponSpawn()
    {
        time += Time.deltaTime;
        Debug.Log(time);
        if(time >= 10)
        {
            rnd = Random.Range(0, 3);
            Instantiate(weapons[rnd], new Vector2(transform.position.x - 3, transform.position.y - 3), Quaternion.identity);
            time = 0;
        }
    }
}
