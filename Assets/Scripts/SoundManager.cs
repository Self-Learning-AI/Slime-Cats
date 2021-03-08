using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource playerAudioSource;
    public AudioClip[] audioClips = new AudioClip[15];
    public bool playIdleSounds = false;
    public float volume = 1.0f;
    public float idleVolume = 0.2f;
    public float stepsVolume = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        playIdleSounds = true;
    }

    private void Update()
    {
        if(playIdleSounds == true)
        {
            StartCoroutine(PlayIdleSounds());
        }
    }

    public void PlaySound(string soundName)
    {
        switch(soundName.ToLower())
        {
            case "fight":
                //play sound on player
                //fight01
                playerAudioSource.clip = audioClips[0];
                playerAudioSource.Play();
                break;
            case "loss":
                //play sound on player
                //aggression5
                playerAudioSource.clip = audioClips[1];
                playerAudioSource.Play();
                break;
            case "victory":
                //play sound on player
                //mow6
                playerAudioSource.clip = audioClips[2];
                playerAudioSource.Play();
                break;
            case "idle":
                //play a random sound on player
                //playerAudioSource.clip = audioClips[3];
                int randomClip = Random.Range(12, 14);
                playerAudioSource.volume = idleVolume;
                playerAudioSource.clip = audioClips[randomClip];
                playerAudioSource.Play();
                playerAudioSource.volume = volume;
                break;
            case "move":
                //play sound on player
                //Slime-Addition03
                playerAudioSource.volume = 0.2f;
                playerAudioSource.clip = audioClips[4];
                playerAudioSource.Play();
                playerAudioSource.volume = volume;
                break;
            case "speak":
                //play sound on player
                //fun meow?
                playerAudioSource.clip = audioClips[5];
                playerAudioSource.Play();
                break;
            case "start":
                //play sound on player
                //fun meow
                playerAudioSource.clip = audioClips[6];
                playerAudioSource.Play();
                break;
            case "quit":
                //play sound on player
                //tom02
                playerAudioSource.clip = audioClips[7];
                playerAudioSource.Play();
                break;
            case "menu":
                //play sound on player
                //mow1
                playerAudioSource.clip = audioClips[8];
                playerAudioSource.Play();
                break;
            case "about":
                //play sound on player
                //mow3
                playerAudioSource.clip = audioClips[9];
                playerAudioSource.Play();
                break;
            case "curious":
                //play sound on player
                //curious02
                playerAudioSource.clip = audioClips[10];
                playerAudioSource.Play();
                break;
            case "play":
                //play sound on player
                //meow02
                playerAudioSource.clip = audioClips[11];
                playerAudioSource.Play();
                break;

        }
    }

    IEnumerator PlayIdleSounds()
    {
        if(playIdleSounds)
        {
            playIdleSounds = false;
            yield return new WaitForSeconds(Random.Range(5.0f, 20.0f));
            PlaySound("idle");
            playIdleSounds = true;
        }

    }
}
