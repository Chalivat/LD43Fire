using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManagers : MonoBehaviour {

    private GameObject[] tilesPos;
    public GameObject[] tilesType1;
    public GameObject[] tilesType2;
    public GameObject[] tilesType3;
    private int rnd;
    private int choose;

    void Start () {
        choose = Random.Range(0, 3);
        tilesPos = GameObject.FindGameObjectsWithTag("tilesSpawner");
        for (int i = 0; i < tilesPos.Length; i++)
        {
            if(choose == 0)
            {
                rnd = Random.Range(0, 10);
                Instantiate(tilesType1[rnd], tilesPos[i].transform.position, transform.rotation);
            }
            if (choose == 1)
            {
                rnd = Random.Range(0, 10);
                Instantiate(tilesType2[rnd], tilesPos[i].transform.position, transform.rotation);
            }
            if (choose == 2)
            {
                Instantiate(tilesType3[rnd], tilesPos[i].transform.position, transform.rotation);
            }
        }
	}
	
	void Update () {
		
	}
}
