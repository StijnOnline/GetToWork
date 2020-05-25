using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour {
    //TODO: can this be made static? and without MonoBehaviour?

    private static AudioPlayer instance;
    public static AudioPlayer Instance { get { return instance; } }
    private AudioSource audioSource;

    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    private void Awake() {
        if(instance != null && instance != this) { Destroy(this.gameObject); } else { instance = this; }
    }
    void Start() {
        AudioClip[] loadedAudio = Resources.LoadAll<AudioClip>("Audio");
        if(loadedAudio != null) {
            foreach(AudioClip audioClip in loadedAudio) {
                audioClips.Add(audioClip.name, audioClip);
            }
        } else {
            Debug.LogWarning("No Audio Resources loaded");
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string audioname, float volume) {
        AudioClip _clip = null;
        if(audioClips.TryGetValue(audioname, out _clip)) {
            audioSource.PlayOneShot(_clip, volume);
        } else {
            Debug.LogWarning("AudioClip not found");
        }
    }
}