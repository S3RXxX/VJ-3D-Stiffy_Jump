using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleTriggers : MonoBehaviour
{
    public float timeToDestroy = 0.001f;
    public GameObject explosion;
    public float timeAnimation = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spikes") 
        {
            Debug.Log("DEAD");

            // fer explotar el player
            Destroy(gameObject, timeToDestroy);

            // fer apareixer FVX
            Instantiate(explosion, transform.position, transform.rotation);

            // wait n seconds
            //yield return new WaitForSeconds(timeAnimation);

            // reiniciar el nivell
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
