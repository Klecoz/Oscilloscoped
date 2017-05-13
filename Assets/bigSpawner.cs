using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigSpawner : MonoBehaviour {

    public GameObject enemy;
    public bool spawn = true;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        GameObject collsphere = GameObject.Find("collidaSphere");
        forcePush fp = collsphere.GetComponent<forcePush>();
        if (fp.score == 3 && !GameObject.FindGameObjectWithTag("bigEnemy") && !spawn)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawn = false;
        }
    }
}
