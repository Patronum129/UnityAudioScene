using UnityEngine;

public class FootstepSoundPlayer : MonoBehaviour
{
    public AudioClip roadFootstepSound;
    public AudioClip sidewalkFootstepSound;
    private AudioSource audioSource;
    private Vector3 lastPosition;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastPosition = transform.position;
    }

    private void Update()
    {
        if (IsPlayerMoving())
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                UnityEngine.Debug.Log(hit.collider.material.name); // Log the material name
                switch (hit.collider.material.name)
                {
                    case "Road (Instance)":
                        if (audioSource.clip != roadFootstepSound)
                        {
                            audioSource.Stop();
                            audioSource.clip = roadFootstepSound;
                        }
                        break;
                    case "SideWalk (Instance)":
                        if (audioSource.clip != sidewalkFootstepSound)
                        {
                            audioSource.Stop();
                            audioSource.clip = sidewalkFootstepSound;
                        }
                        break;
                }
                if (!audioSource.isPlaying) // Ensure the sound doesn't overlap
                {
                    audioSource.Play();
                }
            }
        }
        else if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        lastPosition = transform.position; // Update the last position
    }

    private bool IsPlayerMoving()
    {
        // If the player's position has changed more than a minimum threshold, the player is moving
        float movementThreshold = 0.01f;
        return Vector3.Distance(lastPosition, transform.position) > movementThreshold;
    }
}

