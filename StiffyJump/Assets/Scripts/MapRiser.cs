using UnityEngine;

public class MapRiseEffect : MonoBehaviour
{
    public Transform map; // Assign your map object in the Inspector
    public float startY = -10f; // Starting underground position
    public float endY = 0f; // Final position at ground level
    public float riseSpeed = 2f; // Speed of rising

    private bool isRising = false;

    void Start()
    {
        // Initialize map's position
        map.position = new Vector3(map.position.x, startY, map.position.z);

        // Start the rising animation
        isRising = true;
    }

    void FIxedUpdate()
    {
        if (isRising)
        {
            // Move the map upwards
            map.position = Vector3.MoveTowards(
                map.position,
                new Vector3(map.position.x, endY, map.position.z),
                riseSpeed * Time.deltaTime
            );

            // Stop rising when it reaches the target position
            if (map.position.y >= endY)
            {
                isRising = false;
            }
        }
    }
}
