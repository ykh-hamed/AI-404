using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

	// Use this for initialization
    public Transform[] spots;

    public float Speed;
    float fx, fy, fz;
    public Transform firepoint;
    public GameObject Bullet;
    public GameObject enemies;
    public float health;
    public GameObject laser;
    private PlayerController Player;
    public int movedamage = 2;
	void Start () {
        InvokeRepeating("SpawnEnemies", 0f, 8);
        health = 100;
        Player = FindObjectOfType<PlayerController>();
        StartCoroutine("boss");
        fx = transform.localScale.x;
        fy = transform.localScale.y;
        fz = transform.localScale.z;
	}
	public void takedamage(float damage)
    {
        health -= damage;
        if (health < 0)
            Die();
    }
    public void SpawnEnemies()
    {
        Instantiate(enemies, spots[0].position, spots[0].rotation);
        Instantiate(enemies, spots[1].position, spots[1].rotation);
    }
    void Die()
    {
        Destroy(laser);
        Destroy(this.gameObject);
    }
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            
            FindObjectOfType<PlayerStats>().TakeDamage(movedamage);
            Player.KnockBackCount = 0.2f;
            if (other.transform.position.x < this.transform.position.x)
                Player.KnockFromRight = true;
        }
        if (other.tag == "Borders")
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator boss()
    {
        //First
        while (true)
        {
            while (this.transform.position.x != spots[0].position.x)
            {
               
                this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(spots[0].position.x, this.transform.position.y), Speed);

                yield return null;
            }
            transform.localScale = new Vector3(-1 * fx, fy, fz);
            int i = 0;
            yield return new WaitForSeconds(1);
            while (i < 6)
            {
                GetComponent<Animator>().Play("Enemy2Fire");
                Instantiate(Bullet, firepoint.position, firepoint.rotation);
                i++;
                yield return new WaitForSeconds(.7f);
            }
            //second
            while (this.transform.position != spots[2].position)
            {
                
                this.transform.position = Vector2.MoveTowards(this.transform.position, spots[2].position, Speed);

                yield return null;
            }
            i = 0;
            yield return new WaitForSeconds(1);
            while (i < 6)
            {
                GetComponent<Animator>().Play("Enemy2Fire");
                Instantiate(Bullet, firepoint.position, firepoint.rotation);
                i++;
                yield return new WaitForSeconds(.7f);
            }
            //third
            while (this.transform.position.x != spots[1].position.x)
            {
                
                this.transform.position = Vector2.MoveTowards(this.transform.position, spots[1].position, Speed);

                yield return null;
            }
            transform.localScale = new Vector3( fx, fy, fz);
            i = 0;
            yield return new WaitForSeconds(1);
            while (i < 6)
            {
                GetComponent<Animator>().Play("Enemy2Fire");
                Instantiate(Bullet, firepoint.position, firepoint.rotation);
                i++;
                yield return new WaitForSeconds(.7f);
            }

        }
    }
}
