using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ButtonNoises : MonoBehaviour
{
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        source.volume = Settings.settingsInstance.sfxVolume;
    }
    public void PlayAudio()
    {
        if (source.isPlaying == false)
        {
            source.Play(); 
        }
    }
}
