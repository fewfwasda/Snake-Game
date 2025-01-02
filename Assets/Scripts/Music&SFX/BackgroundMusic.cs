using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    public List<AudioClip> musicPlaylist = new List<AudioClip>();
    public static BackgroundMusic instance;
    private AudioSource music;
    private int indexMusic;
    private void Start()
    {
        indexMusic = musicPlaylist.Count - 1;

        music = GetComponent<AudioSource>();

        musicPlaylist = Shuffle(musicPlaylist);

        music.clip = musicPlaylist[indexMusic];
        music.Play();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    private void Update()
    {
        if (!instance.music.isPlaying)
        {
            PlayNextTrack();
        }
    }
    private void PlayNextTrack()
    {
        if (indexMusic == musicPlaylist.Count - 1)
        {
            musicPlaylist = Shuffle(musicPlaylist);
            indexMusic = 0;
        }
        indexMusic++;
        instance.music.clip = musicPlaylist[indexMusic];
        instance.music.Play();
    }
    private List<AudioClip> Shuffle(List<AudioClip> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

        return list;
    }
}
