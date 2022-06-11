using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameAudioManager : Singleton<gameAudioManager>
{
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public static void Initialize(AudioSource source)
    {
    audio clipleri tek tek enumdan eklemece.

    }
    
    public static void Play(AudioClipName name){
    audioSource.PlayOneShot(audioClips[name]);}
     
     */
}
