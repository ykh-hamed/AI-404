using UnityEngine;
using System.Collections;

public class EnemyCameraController : MonoBehaviour {

	// Use this for initialization
    public Transform firePoint;
    private PlayerController Player;
    public GameObject Bullet;
    public GameObject Laser;
	void Start () {
        Player = FindObjectOfType<PlayerController>();
        InvokeRepeating("Shoot", 0f, 1F);
	}
    public void Shoot()
    {
        Instantiate(Bullet, firePoint.position, firePoint.rotation);
    }
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        if (Player.transform.position.x < transform.position.x)
            this.GetComponent<Animator>().Play("CameraAnimationLeft");
        else
            this.GetComponent<Animator>().Play("CameraAnimationRight");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            
            Destroy(Laser.gameObject);
        }
    }
}
