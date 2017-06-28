using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {

	// Use this for initialization
    public Transform firePoint;
    private PlayerController Player;
    public float RepeatRate; 
    public GameObject Bullet;
	void Start () {
        InvokeRepeating("Shoot", 0f, RepeatRate);
      //  InvokeRepeating("Move", 0f, 0.1F);
        Player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(Bullet, firePoint.position, firePoint.rotation);
        GetComponent<Animator>().Play("Enemy2Fire");
        if (this.transform.rotation.y == 0)
            bullet.GetComponent<Enemy2BulletController>().speed = 20;
        else
            bullet.GetComponent<Enemy2BulletController>().speed = -20;

    }
    //public void Move()
    //{
    //    this.transform.position = new Vector3(Vector3.MoveTowards(this.transform.position, Player.transform.position, 10 * Time.deltaTime).x, this.transform.position.y);
    //}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            FindObjectOfType<PlayerStats>().TakeDamage(10);
            Player.KnockBackCount = 0.2f;
            if (other.transform.position.x < transform.position.x)
                Player.KnockFromRight = true;
        }

    }

}
