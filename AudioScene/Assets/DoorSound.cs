using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public AudioClip doorSoundClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Assign the audio clip in AudioSource
        audioSource.clip = doorSoundClip;
    }

    public void PlayDoorSound()
    {
        audioSource.Play();
    }
}
