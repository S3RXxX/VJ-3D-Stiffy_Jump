using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public float initialSpeed = 20f; // Initial speed of the object
    public float deceleration = 10f; // Deceleration rate
    public float maxDistance = 10f; // Maximum distance the object can move
    public float triggerDistance = 5f; // Distance to the Player to start moving
    public bool moveToRight = true; // If true, move to the right; otherwise, move to the left

    private Vector3 startPosition; // Starting position of the object
    private bool isMoving = false; // Whether the object is moving
    private float movedDistance = 0f; // Distance the object has moved
    private float currentSpeed; // Current speed of the object

    void Start()
    {
        // Record the starting position of the object
        startPosition = transform.position;
        currentSpeed = initialSpeed; // Set initial speed
    }

    void Update()
    {
        // Check if the object is already moving
        if (!isMoving)
        {
            // Find the Player object
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                Debug.Log("Player detected!");
                // Calculate the distance to the Player
                float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

                // Start moving if close enough to the Player
                if (distanceToPlayer <= triggerDistance)
                {
                    isMoving = true;
                }
            }
        }
        else
        {
            // Calculate the distance to move this frame
            float moveStep = currentSpeed * Time.deltaTime;
            movedDistance = moveStep;

            // Move the object forward
            if (movedDistance <= maxDistance)
            {
                Vector3 moveDirection = moveToRight ? transform.right : -transform.right;
                transform.Translate(moveDirection * moveStep, Space.World);

                // Decelerate the object
                currentSpeed = Mathf.Max(0, currentSpeed - deceleration * Time.deltaTime);
            }
            else
            {
                // Stop moving after reaching the maximum distance
                isMoving = false;
            }
        }
    }
}
