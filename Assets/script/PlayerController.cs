using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    public Transform bulletSpawnPoint;
    public GameObject Bullet;
    public float bulletSpeed = 10;

    //public GameManager myGameManager;
    public TextMeshProUGUI scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        score = 0; scoreText.text = "Score: " + score;
        UpdateScore(0);
        StartCoroutine(WalkCoRutine());
    // myGameManager = FindObjectOfType<GameManager>();
    //scoreText.text = myGameManager.score.ToString();

}
    private void UpdateScore(int scoreToAdd) 
    { 
        score += scoreToAdd; 
        scoreText.text = "Score: " + score; 
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x,playerJumpForce);
           // myrigidbody2D.velocity = new Vector2(playerSpeed, myrigidbody2D.velocity.y);
        }
        myrigidbody2D.velocity = new Vector2(playerSpeed, myrigidbody2D.velocity.y);
        if (Input.GetKeyDown(KeyCode.E))
        {
             Instantiate(Bullet, transform.position, Quaternion.identity);
            //var bullet = Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            //bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;       
        }

    }

    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if (index == 4)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRutine());


    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemGood"))
        {
            Destroy(collision.gameObject);
            UpdateScore(10);
            //myGameManager.AddScore();
            //scoreText.text = myGameManager.textScore.ToString();

        }
        else if (collision.CompareTag("Itembad"))
        { 
            Destroy(collision.gameObject);
            UpdateScore(5);
           // PlayerDeath();
        }
        else if (collision.CompareTag("Itembad2"))
        {
            Destroy(collision.gameObject);
            UpdateScore(5);


            //PlayerDeath();
        }        
        else if(collision.CompareTag("Deathzone"))
            //Deathzone
        {
            PlayerDeath();
        }
    }
    void PlayerDeath()
    {
        //SceneManager.LoadScene("Nivel1");
        SceneManager.LoadScene("Lose");
    }
}