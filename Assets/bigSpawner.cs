using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigSpawner : MonoBehaviour {

    public GameObject enemy;
    public bool spawn = true;
    public int count = 31;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        GameObject collsphere = GameObject.Find("collidaSphere");
        forcePush fp = collsphere.GetComponent<forcePush>();
        if (fp.score == 3 && !GameObject.FindGameObjectWithTag("bigEnemy") && !spawn && name == "bigSpawnLeft")
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawn = false;
        }

        if (fp.score == 6 && !GameObject.FindGameObjectWithTag("bigEnemy") && !spawn && (name == "bigSpawnRight"))
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawn = false;
        }

        if (fp.score == 9 && !GameObject.FindGameObjectWithTag("bigEnemy") && !spawn && (name == "bigSpawnLeft"))
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawn = false;
        }

        if (fp.score == 12 && !GameObject.FindGameObjectWithTag("bigEnemy") && !spawn && (name == "bigSpawnRight"))
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawn = false;
        }

        if (fp.score == 13 && !GameObject.FindGameObjectWithTag("bigEnemy") && !spawn && (name == "bigSpawnLeft"))
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawn = false;
        }

        if (fp.score == 17 && !GameObject.FindGameObjectWithTag("bigEnemy") && !spawn && (name == "bigSpawnRight"))
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawn = false;
        }

        if (fp.score == 19 && !GameObject.FindGameObjectWithTag("bigEnemy") && !spawn && (name == "bigSpawnLeft"))
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawn = false;
        }

        if (fp.score == 23 && !GameObject.FindGameObjectWithTag("bigEnemy") && !spawn && (name == "bigSpawnLeft"))
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawn = false;
        }

        if (fp.score == 27 && !GameObject.FindGameObjectWithTag("bigEnemy") && !spawn && (name == "bigSpawnRight"))
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawn = false;
        }

        if (fp.score == 31 && !GameObject.FindGameObjectWithTag("bigEnemy") && !spawn && (name == "bigSpawnLeft"))
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawn = false;
        }

        if (fp.score == 33 && !GameObject.FindGameObjectWithTag("bigEnemy") && !spawn && (name == "bigSpawnRight"))
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawn = false;
        }

        if (fp.score == 35 && !GameObject.FindGameObjectWithTag("bigEnemy") && !spawn && (name == "bigSpawnLeft"))
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawn = false;
        }

        if (fp.score == 36 && !GameObject.FindGameObjectWithTag("bigEnemy") && !spawn && (name == "bigSpawnRight"))
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawn = false;
        }

        if (fp.score == 37 && !GameObject.FindGameObjectWithTag("bigEnemy") && !spawn && (name == "bigSpawnLeft"))
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawn = false;
        }

    }
}
