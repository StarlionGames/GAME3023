using System.Collections.Generic;
using UnityEngine;

public enum AudioDirectory
{
    StartMusic = 0,
    OverworldMusic = 1,
    BattleMusic = 2
}
public class AudioManager : MonoBehaviour
{
    public List<AudioClip> BGM;
    public AudioSource audioPlayer;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void ChangeBGM(AudioDirectory num)
    {
        if (audioPlayer.clip == BGM[(int)num]) { return; }
        
        audioPlayer.Stop();
        audioPlayer.clip = BGM[(int)num];
        audioPlayer.Play();
    }
}
