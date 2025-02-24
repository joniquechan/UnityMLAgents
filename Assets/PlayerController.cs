using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    private Rigidbody rb;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position; 
    }

    void Update()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0, moveZ) * moveSpeed;
        rb.AddForce(moveDirection, ForceMode.Acceleration);

        if (transform.position.y < 0)
        {
            ResetPlayer();
        }
    }

    void ResetPlayer()
    {
        // Reset player position
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;

        Debug.Log("Player fell! Resetting position...");
    }
}
