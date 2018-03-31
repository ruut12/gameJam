using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    // call this using FindObjectOfType<AudioManager>().Play(name_of_clip);

    public static AudioManager instance;

    public Sound[] sounds;

	void Awake () {
        if(instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    void Start () {
        Play("theme");
    }

    // Update is called once per frame
    public void Play (string name) {
        Sound s = Array.Find(sounds, s => s.name == name);

        if (s != null) {
            s.source.Play();
        } else {
            Debug.LogWarning("Sound " + name + " not found");
        }
	}
}
