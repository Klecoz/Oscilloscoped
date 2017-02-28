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

        Vector3 randomSize = new Vector3(Random.Range(6, 10), Random.Range(6, 10), Random.Range(6, 10));

        ene.transform.localScale = randomSize;
    }
}
