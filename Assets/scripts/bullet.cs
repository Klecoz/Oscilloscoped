using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour {

    public GameObject explode;




    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        /*forcePush fp = GetComponent<forcePush>();
        fp.score++; */

        Destroy(gameObject, 3f);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //fp.score++;
            GameObject collsphere = GameObject.Find("collidaSphere");
            forcePush fp = collsphere.GetComponent<forcePush>();
            fp.score++;
            Instantiate(explode, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(GameObject.FindWithTag("explode"), .5f);
            Destroy(this.gameObject);
        }

    }

}
