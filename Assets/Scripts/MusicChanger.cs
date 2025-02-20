using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;

    public void PlayMusic1()
    {
        musicSource.clip = music1;
        musicSource.Play();
    }

    public void PlayMusic2()
    {
        musicSource.clip = music2;
        musicSource.Play();
    }

    public void PlayMusic3()
    {
        musicSource.clip = music3;
        musicSource.Play();
    }
}