using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public int coins;
    public float timeToDestroy = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            coins += 1;
            Destroy(other.gameObject, timeToDestroy);
        }
    }
}
