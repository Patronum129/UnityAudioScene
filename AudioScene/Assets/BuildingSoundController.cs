using UnityEngine;
using UnityEngine.Audio;

public class BuildingSoundController : MonoBehaviour
{
    public AudioMixerSnapshot exteriorSnapshot;
    public AudioMixerSnapshot interiorSnapshot;
    public float transitionTime = 1.0f; // time in seconds to transition between snapshots

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the colliding object is the player
        {
            interiorSnapshot.TransitionTo(transitionTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the colliding object is the player
        {
            exteriorSnapshot.TransitionTo(transitionTime);
        }
    }
}
