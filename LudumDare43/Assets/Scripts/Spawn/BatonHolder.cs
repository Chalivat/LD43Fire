using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatonHolder : MonoBehaviour {

    private GameObject[] spawnerPos;
    public GameObject baton;
    private int rnd;
    private int count;
    public int StartCount;

    void Start () {
        count = 0;
    }
	
	void Update () {
        rnd = Random.Range(0, 400);
        spawnerPos = GameObject.FindGameObjectsWithTag("SpawnerPos");

        if (count < StartCount)
        {
            Instantiate(baton, spawnerPos[rnd].transform.position, Quaternion.identity);
            count += 1;
        }
    }
}
