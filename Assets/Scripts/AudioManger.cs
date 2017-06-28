using UnityEngine;
using System.Collections;

public class AudioManger : MonoBehaviour {
    public AudioSource musicSource;
    public static AudioManger instance = null;
	// Use this for initialization
	void Awake () {
        //if (instance == null)
        //    instance = this;
        //else if (instance != this)
        //    Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void playSingle(AudioClip clip)
    {
        musicSource.clip = clip;

        musicSource.Play();
    }
}
