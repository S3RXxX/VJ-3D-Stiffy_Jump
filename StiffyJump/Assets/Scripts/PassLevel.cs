using UnityEngine;

public class PassLevel : MonoBehaviour
{
    LevelManager levelManager;
    private void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager")?.GetComponent<LevelManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelManager.NextLevel();
        }
    }
}
