using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 100f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Move the camera in the direction it's facing
        Vector3 horizontalMovement = transform.right * horizontal * moveSpeed * Time.deltaTime;
        horizontalMovement.y = 0f;
        Vector3 forwardMovement = transform.forward * vertical * moveSpeed * Time.deltaTime;
        forwardMovement.y = 0f;
        transform.position += horizontalMovement + forwardMovement;

        // Rotate the camera using the mouse
        float rotateHorizontal = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float rotateVertical = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

        transform.RotateAround(transform.position, Vector3.up, rotateHorizontal);
        transform.RotateAround(transform.position, transform.right, -rotateVertical);
    }
}
