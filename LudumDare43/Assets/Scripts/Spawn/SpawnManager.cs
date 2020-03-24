using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    private GameObject[] spawnerPos;
    public GameObject spawner;
    public GameObject[] spawners;
    public spawnerBehavior spawnerBe;
    public bool isTriggered = false;
    private int rnd;
    private int count;
    public int StartCount;
    public bool isFire = false;

	void Start () {

        count = 0;
	}
	
	void Update () {

        rnd = Random.Range(0, 400);
        spawnerPos = GameObject.FindGameObjectsWithTag("SpawnerPos");

        if(count < StartCount && isFire == false)
        {
            Instantiate(spawner, spawnerPos[rnd].transform.position, Quaternion.identity);
            count += 1;
        }

        if (isTriggered)
        {
            spawners = GameObject.FindGameObjectsWithTag("Spawner");

            for (int i = 0; i < spawners.Length; i++)
            {
                spawners[i].GetComponent<spawnerBehavior>().isDestroyed = true;
            }
        }
    }
}
