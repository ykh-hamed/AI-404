using UnityEngine;
using System.Collections;

public class LevelManger : MonoBehaviour {
    public GameObject CurrentCheckpoint;
    public Transform enemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void RespawnEnemy()
    {
        Instantiate(enemy, CurrentCheckpoint.transform.position, CurrentCheckpoint.transform.rotation);
    }
}
