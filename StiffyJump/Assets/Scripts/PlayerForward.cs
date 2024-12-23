using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerForward : MonoBehaviour
{
    public float speed = 12.5f;
    private PathFollower pathFollower;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pathFollower = GetComponent<PathFollower>();
    }

    void FixedUpdate()
    {
        //transform.Translate(0f, 0f, 0.1f);

        //Vector3 move = pathFollower.outVelocity * speed * Time.fixedDeltaTime;
        Vector3 move = transform.forward * speed * Time.fixedDeltaTime;

        CollisionFlags flags = GetComponent<CharacterController>().Move(move);
        if ((flags & CollisionFlags.Sides) != 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
