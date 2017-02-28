using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class forcePush : MonoBehaviour {

    public int health = 5;
    public int score = 0;
    public int powerLimit = 5;
    public GameObject ring;
    public GameObject explode;
    public GameObject projectile;
    public bool gameOver = false;
    public AudioClip shootSound;
    public Text myTextHealth;
    public Text myTextScore;

    public float ringTime;
    public float destroyTime = 0.1f;

    private AudioSource source;
    public List<Asteroid> _touchingAsteroids = new List<Asteroid>();


    void Awake()
    {

        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        myTextHealth = GameObject.Find("health").GetComponent<Text>();
        myTextScore = GameObject.Find("score").GetComponent<Text>();

        Attack();
        Move();

            if (health == 0 && gameOver == false)
        {
            var getPlayer = GameObject.FindGameObjectWithTag("Player");
            Instantiate(explode, new Vector3 (0,0,0), Quaternion.identity);
            SceneManager.LoadScene(0);
            Destroy(getPlayer);
            Destroy(GameObject.FindWithTag("explode"), 1);
            gameOver = true;

            
        }

       if (score == 5)
        {

        }

    }

    void Attack()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            GameObject bullet = Instantiate(projectile, transform.forward, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 300);
            
            source.PlayOneShot(shootSound);
        }
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_touchingAsteroids.Count == 0)
                return;
            /*
            for(int x = 0; x<_touchingAsteroids.Count; x++)
            {
                Asteroid a = _touchingAsteroids[x];
            }
            */

            foreach(Asteroid a in _touchingAsteroids)
            {
                if (a != null && powerLimit != 0)
                {
                    //a.gameObject.GetComponent<Rigidbody>().AddForce(0, 500, 0);
                    Instantiate(explode, a.transform.position, a.transform.rotation);
                    Destroy(a.gameObject, destroyTime);
                    Destroy(GameObject.FindWithTag("explode"), .5f);
                    score++;
                    myTextScore.text = "Score: " + score;
                    powerLimit--;
                }
            }

            if (powerLimit != 0)
            {
                GameObject instantiatedRing = Instantiate(ring);
                StartCoroutine(Grow(instantiatedRing, ringTime, 5));
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
            }


        }

        


    }

    void OnCollisionEnter(Collision collision)
    {
        Asteroid a = collision.collider.GetComponent<Asteroid>();
        if (a != null)
        {
            _touchingAsteroids.Add(a);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Asteroid a = collision.collider.GetComponent<Asteroid>();
        if (a != null)
        {
            _touchingAsteroids.Remove(a);
        }
    }

  
    /*
    void OnCollisionStay(Collision other)
    {
            
            //float force = 3;
            
            // If the object we hit is the enemy
            if (other.gameObject.tag == "Enemy")
            {
            Debug.Log(other + " is colliding");

            Debug.Log(Time.deltaTime + " is the time between frames");

            if (Input.GetKeyUp("space"))
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(0, 500, 0);
                Destroy(other.gameObject, 1);


                GameObject instantiatedRing = Instantiate(ring);
                StartCoroutine(Grow(instantiatedRing, ringTime, 5));
                AudioSource audio = GetComponent<AudioSource>();
                audio.pitch = Random.Range(1 - rando, 1 + rando);
                audio.Play();
                //Instantiate(ring, transform.localScale * 10 * Time.deltaTime, transform.rotation);

            }


            }

    }*/

    public void TakeDamage(int damageAmount)
    {
        health = health - damageAmount;
        myTextHealth.text = "Health: " + health;



        Debug.Log("We took " + damageAmount + " damage");
        Debug.Log("Health is now " + health);
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * 120 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.up * 120 * Time.deltaTime);
        }
    }

    IEnumerator Grow(GameObject thingToGrow, float timeBig, float bigScale)
    {
        float initial = thingToGrow.transform.localScale.x;
        float final = bigScale * initial;
        float diff = final - initial ;
        float rate = diff / timeBig;
        while (thingToGrow.transform.localScale.x < final)
        {
            float newScale = thingToGrow.transform.localScale.x + rate * Time.deltaTime;
            if (newScale > final)
            {
                newScale = final;
            }
            thingToGrow.transform.localScale = new Vector3(newScale, newScale, newScale);
            yield return new WaitForEndOfFrame();
        }


        Destroy(thingToGrow);
    }

}
