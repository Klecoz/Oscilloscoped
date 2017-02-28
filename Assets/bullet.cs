using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Instantiate(explode, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(GameObject.FindWithTag("explode"), 1);
        }
        
        

    }

    void updateScore ()
    {
        
        /*fp.score = fp.score + 1;
        fp.myTextScore.text = "Score: " + fp.score;*/

    }
}
