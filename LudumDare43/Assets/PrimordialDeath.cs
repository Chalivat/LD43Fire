using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimordialDeath : MonoBehaviour
{

    public CircleCollider2D circle;
    public GameObject black;
    public GameObject grey;
    public GameObject panelLose;
    public GameObject panelWin;
    private int spawner;
    private bool isWaiting = true;
    private float time;


    void Start()
    {
        panelLose.SetActive(false);
        panelWin.SetActive(false);
    }

    void Update()
    {
        spawner = GameObject.FindGameObjectsWithTag("Spawner").Length;
        Debug.Log(spawner);
        time += Time.deltaTime;
        if(time > 10)
        {
            isWaiting = false;
        }

        if (!isWaiting)
        {
            if (circle.radius <= 0)
            {
                panelLose.SetActive(true);
                panelWin.SetActive(false);
                Time.timeScale = 0;
            }

            if (spawner <= 0)
            {
                panelLose.SetActive(false);
                panelWin.SetActive(true);
                Time.timeScale = 0;
            }
        }
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemy"))
        {
            circle.radius -= 0.01f * Time.deltaTime;
            black.transform.localScale -= new Vector3(0.3f * Time.deltaTime, 0.3f * Time.deltaTime, 0);
            grey.transform.localScale -= new Vector3(0.3f * Time.deltaTime, 0.3f * Time.deltaTime, 0);
        }
    }
}

