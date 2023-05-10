using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public Transform targetObject; // The object that will move
    public Vector3 newPos; // The new position the object will move to
    public AudioClip enterSound; // Sound to play when player enters the trigger
    public AudioClip exitSound; // Sound to play when player exits the trigger
    public float speed = 2.0f; // Speed at which the object moves

    private Vector3 originalPos; // The original position of the object
    private AudioSource audioSource; // The AudioSource to play the sounds
    private Vector3 targetPos; // The current target position

    private void Start()
    {
        originalPos = targetObject.position;
        targetPos = originalPos; // Initially, the target position is the original position
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Move the target object towards the target position
        targetObject.position = Vector3.MoveTowards(targetObject.position, targetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the colliding object is the player
        {
            targetPos = newPos;
            audioSource.clip = enterSound;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the colliding object is the player
        {
            targetPos = originalPos;
            audioSource.clip = exitSound;
            audioSource.Play();
        }
    }
}

