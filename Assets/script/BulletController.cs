using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float life = 3;

    private Rigidbody2D myrigidbody2D;
    public float bulletSpeed = 50f;
    public GameManager myGameManager;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        myGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        myrigidbody2D.velocity = new Vector2(bulletSpeed, myrigidbody2D.velocity.y);
     
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ItemGood") )
        {
            myGameManager.AddScore();
            Destroy(collision.gameObject);
            //collision.gameObject.GetComponent<myrigidbody2D>();
        }
        else if (collision.CompareTag("ItemBad"))
        {
            myGameManager.AddScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("ItemBad2"))
        {
            myGameManager.AddScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        
    }
    void Awake()
    {
        Destroy(gameObject, life);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);

    }
}
