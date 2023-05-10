using UnityEngine;

public class FootstepSoundPlayer : MonoBehaviour
{
    public AudioClip roadFootstepSound;
    public AudioClip sidewalkFootstepSound;
    private AudioSource audioSource;
    private Vector3 lastPosition;
    private string lastMaterialName;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastPosition = transform.position;
        lastMaterialName = "";
    }

    private void Update()
    {
        if (IsPlayerMoving())
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                UnityEngine.Debug.Log(hit.collider.material.name); // Log the material name
                if (lastMaterialName != hit.collider.material.name)
                {
                    lastMaterialName = hit.collider.material.name;
                    audioSource.Stop();
                    switch (lastMaterialName)
                    {
                        case "Road (Instance)":
                            audioSource.clip = roadFootstepSound;
                            break;
                        case "SideWalk (Instance)":
                            audioSource.clip = sidewalkFootstepSound;
                            break;
                    }
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
