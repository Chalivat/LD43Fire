using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decors : MonoBehaviour {

    private GameObject[] spawnerPos;
    public GameObject[] trees;
    private int rnd;
    private int rndTree;
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
            rndTree = Random.Range(0, 10);
            Instantiate(trees[rndTree], spawnerPos[rnd].transform.position, Quaternion.identity);
            count += 1;
        }
    }
}
