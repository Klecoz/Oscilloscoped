using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour {

    public GameObject explode;
    public GameObject healthBonusImage;
    public GameObject bigHealthRemove;



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

        if (GameObject.FindWithTag("bigEnemy") != null)
        {
            bigHealthRemove = GameObject.FindGameObjectWithTag("bigEnemy");
            bigAsteroid removeBig = bigHealthRemove.GetComponent<bigAsteroid>();

            if (collision.gameObject.tag == "bigEnemy" && removeBig.bigAsteroidHealth > 0)
            {
                removeBig.bigAsteroidHealth = removeBig.bigAsteroidHealth - 1;
                Destroy(gameObject);
            }

            if (collision.gameObject.tag == "bigEnemy" && removeBig.bigAsteroidHealth == 0)
            {
                //fp.score++;
                GameObject collsphere = GameObject.Find("collidaSphere");
                forcePush fp = collsphere.GetComponent<forcePush>();
                fp.score++;
                if (fp.health < 5)
                {
                    fp.health++;
                    fp.addHealth();
                }
                Instantiate(explode, collision.transform.position, collision.transform.rotation);
                Instantiate(healthBonusImage, collision.transform.position, collision.transform.rotation);
                Destroy(collision.gameObject);
                Destroy(GameObject.FindWithTag("explode"), .5f);
                Destroy(GameObject.FindWithTag("healthExplode"), .9f);
                Destroy(this.gameObject);
            }
        }

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
