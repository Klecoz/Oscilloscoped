using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class forcePush : MonoBehaviour
{

    public int health = 5;
    public int score = 0;
    public int powerLimit = 5;
    //Don't even have the ring anymore!
    public GameObject ring;
    public GameObject explode;
    public GameObject projectile;
    public bool gameOver = false;
    public AudioClip shootSound;
    //Health is done with Pics now
    public Text myTextHealth;
    public Text myTextScore;
    public Text myHighScore;

    public float destroyTime = 0.1f;
    //Screen Shake
    public GameObject mahCamera;
    //Game Spawners
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;

    //Health Images
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;
    public GameObject health5;

    //GameOver UI
    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject highScoreUI;

    private AudioSource source;
    public float nextFire = -1.0f;

    //High Score
    public int highScore = 0;
    string highScoreKey = "HighScore";


    void Awake()
    {

        source = GetComponent<AudioSource>();

    }

    // Use this for initialization
    void Start()
    {
        nextFire = Time.time;
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //myTextHealth = GameObject.Find("health").GetComponent<Text>();
        myTextScore = GameObject.Find("score").GetComponent<Text>();

        myTextScore.text = "Score: " + score;

        if (Time.time >= nextFire)
        {
            Attack();
        }

        Move();
        resetGame();
        cheatCode();

        if (health == 0 && gameOver == false)
        {
            var getPlayer = GameObject.FindGameObjectWithTag("Player");
            GameObject[] getSpawners = GameObject.FindGameObjectsWithTag("spawners");
            Instantiate(explode, new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(GameObject.FindWithTag("explode"), 1);
            Destroy(GameObject.FindWithTag("Enemy"));

            foreach (GameObject go in getSpawners)
            {
                go.GetComponent<spawner>().CancelInvoke("spawn");
                Destroy(GameObject.FindWithTag("Enemy"));
                go.SetActive(false);
                go.GetComponent<spawner>().enabled = false;
            }

            UI1.SetActive(true);
            UI2.SetActive(true);
            UI3.SetActive(true);
            highScoreUI.SetActive(true);
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt(highScoreKey, score + 1);
                PlayerPrefs.Save();
            }

            myHighScore = GameObject.Find("highScore").GetComponent<Text>();
            myHighScore.text = "High Score: " + highScore;
            

            Destroy(getPlayer);
            gameOver = true;


        }

        if (score == 5)
        {
            spawn1.SetActive(true);
            spawn2.SetActive(true);
        }

        if (score == 10)
        {
            spawn3.SetActive(true);
            spawn4.SetActive(true);
            spawn5.SetActive(true);
        }

    }

    void Attack()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameObject bullet = Instantiate(projectile, transform.forward, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 300);
            nextFire = Time.time + .3f;
            source.PlayOneShot(shootSound);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        TakeDamage(1);
        mahCamera.GetComponent<Camera>().Shake();

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

        if (health == 4)
        {
            health1.SetActive(false);
        }
        if (health == 3)
        {
            health2.SetActive(false);
        }
        if (health == 2)
        {
            health3.SetActive(false);
        }
        if (health == 1)
        {
            health4.SetActive(false);
        }
        if (health == 0)
        {
            health5.SetActive(false);
        }

        //myTextHealth.text = "Health: " + health;



        Debug.Log("We took " + damageAmount + " damage");
        Debug.Log("Health is now " + health);
    }

    public void addHealth()
    {
        if (health == 5)
        {
            health1.SetActive(true);
        }
        if (health == 4)
        {
            health2.SetActive(true);
        }
        if (health == 3)
        {
            health3.SetActive(true);
        }
        if (health == 2)
        {
            health4.SetActive(true);
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * 150 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-Vector3.up * 150 * Time.deltaTime);
        }
    }

    void resetGame()
    {
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("Title");
        }
    }

    void cheatCode()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            Destroy(GameObject.FindGameObjectWithTag("bigEnemy"));
        }
    }


}
