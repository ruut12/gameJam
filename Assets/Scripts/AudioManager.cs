using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    // call this using FindObjectOfType<AudioManager>().Play(name_of_clip);
    //public static AudioManager instance;
    static System.Random rnd = new System.Random();

    public Sound[] sounds;

	void Awake () {
        /*
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        */
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spacialBlend;
        }
	}

    void Start () {
        //Play("theme");
    }

    public void Play (string name) {
        Sound[] s = Array.FindAll(sounds, sound => sound.name == name);
        int r = rnd.Next(s.Length);

        if (s != null && s.Length > 0)
        {
            s[r].source.Play();
        } else
        {
            Debug.LogWarning("Sound " + name + " not found");
        }
	}
}
