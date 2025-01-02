using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class MapRiseEffect : MonoBehaviour
{
    public float undergroundY = -2.5f; // Starting underground position
    public float groundY = 0f; // Final position at ground level
    public float speed = 5f; // Speed of rising
    public bool passed = false;
    public bool dead = false;

    PlayerForward playerForward;

    void Start()
    {
        if (PlayerPrefs.GetInt("Level") == 2)
        {
            undergroundY = -95f;
        }
        groundY = transform.position.y;
        // Ensure the map starts in the correct position
        transform.position = new Vector3(transform.position.x, undergroundY, transform.position.z);

        // Make the map rise when the scene starts
        Rise();
    }

    private void Awake()
    {
        playerForward = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerForward>();
    }


    //void Update()
    //{
    //    // Check if the level is passed and the map needs to go underground
    //    if (passed || dead)
    //    {
    //        Lower();
    //    }
    //}

    public void Rise()
    {
        //playerForward.moveSpeed = playerForward.speed;
        //Debug.Log("playerForward.moveSpeed " + playerForward.moveSpeed);
        playerForward.speed = 0;
        //StopAllCoroutines(); // Stop any ongoing animations
        StartCoroutine(MoveMap(groundY));
    }


    public void Lower()
    {
        //StopAllCoroutines(); // Stop any ongoing animations
        StartCoroutine(MoveMap(undergroundY));
    }

    private IEnumerator MoveMap(float targetY)
    {
        while (Mathf.Abs(transform.position.y - targetY) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(transform.position.x, targetY, transform.position.z),
                speed * Time.deltaTime
            );
            yield return null;
        }
        passed = false;
        playerForward.speed = playerForward.moveSpeed;
    }



}
