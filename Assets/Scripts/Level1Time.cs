using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level1Time : MonoBehaviour {

	// Use this for initialization
    public float endtime;
    public Text TimeUI;
	void Start () {
        endtime += Time.time;
	}
	
	// Update is called once per frame
	void Update () {
       
            TimeUI.text = "" + ((int)(endtime - Time.time)).ToString();
	
	}
    void FixedUpdate()
    {
        if (Time.time >= endtime)
            Application.LoadLevel("GameOverScene");
    }
}
