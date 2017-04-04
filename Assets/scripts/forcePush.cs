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
    public float destroyTime = 0.1f;

    //Game Spawners
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;

    private AudioSource source;


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

        myTextScore.text = "Score: " + score;

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
            spawn1.SetActive(true);
            spawn2.SetActive(true);
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

    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        TakeDamage(1);
    }

   /* void OnCollisionExit(Collision collision)
    {
        Asteroid a = collision.collider.GetComponent<Asteroid>();
        if (a != null)
        {
            
        }
    }
    */


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

}
