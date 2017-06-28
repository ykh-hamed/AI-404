using UnityEngine;
using System.Collections;

public class Enemy2BulletController : MonoBehaviour {

    public float speed;
    public int damage;
    private PlayerController Player;


    // Use this for initialization
    void Start()
    {
        Player = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
         
            Destroy(this.gameObject);
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Player.KnockBackCount = 0.2f;
            if (other.transform.position.x < this.transform.position.x)
                Player.KnockFromRight = true;
        }
        if (other.tag == "Borders")
        {
            Destroy(this.gameObject);
        }
    }
}
