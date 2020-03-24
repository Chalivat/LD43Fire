using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereFollow : MonoBehaviour {

    private Transform target;
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	void Update () {
        transform.position = new Vector3(target.position.x,target.position.y, 10 * -1);
	}
}
