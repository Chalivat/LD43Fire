using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerBehavior : MonoBehaviour {

    public GameObject ennemis;
    private GameObject[] spawnerPos;
    public GameObject spawner;
    private int count;
    private int rnd;
    private float timeBtwSpawn;
    private float timeWhenDestroyed;
    private float generalTime;
    public SpawnManager spawnManager;
    public bool isDestroyed = false;
    private bool dead = false;

	void Start () {

        generalTime = 0;
        timeWhenDestroyed = 45;
	}
	
	void Update () {

        generalTime += Time.deltaTime;
        spawnerPos = GameObject.FindGameObjectsWithTag("SpawnerPos");
        count = GameObject.FindGameObjectsWithTag("SpawnerPos").Length;

        Spawn();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire") || collision.gameObject.CompareTag("fire"))
        {
            GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>().isFire = true;
            GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>().isTriggered = true;
            dead = true;
            /*rnd = Random.Range(0, count);
            Instantiate(spawner, spawnerPos[rnd].transform.position, Quaternion.identity);*/
        }
    }

    void Spawn()
    {
        if (!dead) {
            timeBtwSpawn += Time.deltaTime;
            //Debug.Log(timeBtwSpawn);

            if (isDestroyed == true)
            {
                isDestroyed = false;
                timeWhenDestroyed -= 0.05f * Time.deltaTime;
            }
            if (timeBtwSpawn >= timeWhenDestroyed)
            {
                Instantiate(ennemis, transform.position, Quaternion.identity);
                timeBtwSpawn = 0;
            }
        }
           
    }
}
