using UnityEngine;
using System.Collections;

public class HingeButtonController : MonoBehaviour {

	// Use this for initialization
    public GameObject hinge;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            hinge.GetComponent<Rigidbody2D>().isKinematic = false;
            Destroy(other);
        }
    }
}
