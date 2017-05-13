using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigAsteroid : MonoBehaviour {

    public GameObject explode;
    public int bigAsteroidHealth = 2;
	// Use this for initialization
	void Start () {
        GameObject collsphere = GameObject.Find("collidaSphere");
        forcePush fp = collsphere.GetComponent<forcePush>();

        if (fp.score > 20)
        {
            bigAsteroidHealth =  3;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
