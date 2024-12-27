using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    string sceneToLoad;
    void Start()
    {
        sceneToLoad = SceneManager.GetActiveScene().name;
    }
    
    public void RestartLevel(float delayTime)
    {
        StartCoroutine(RestartLevelAfterDelay(delayTime));
    }

    private IEnumerator RestartLevelAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneToLoad); // Restart the current scene
    }
}
