using UnityEngine;
using System.Collections;

public class EnemyCameraBulletController : MonoBehaviour {

	// Use this for initialization
    private PlayerController Player;
    public float MoveSpeed = 50;
    public int damage = 5;
    public Vector3 oldplayerpos;
	void Start () {
        Player = FindObjectOfType<PlayerController>();
        oldplayerpos = Player.transform.position;
      
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector3.MoveTowards(this.transform.position, oldplayerpos, MoveSpeed * Time.deltaTime);
        if (this.transform.position == oldplayerpos)
            Destroy(this.gameObject);

        
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
