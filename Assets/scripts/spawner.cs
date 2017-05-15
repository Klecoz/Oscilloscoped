using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public GameObject enemy;
    public float spawnTime;

    void Start()
    {
        InvokeRepeating("spawn", spawnTime, spawnTime);
    }

    void spawn()
    {
        GameObject ene = Instantiate(enemy, transform.position, transform.rotation) as GameObject;

        Vector3 randomSize = new Vector3(Random.Range(4f, 12f), Random.Range(4f, 12f), Random.Range(4f, 12f));
        //Debug.Log("random size " + randomSize);
        ene.transform.localScale = randomSize;
    }
}
