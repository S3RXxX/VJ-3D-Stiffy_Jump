using UnityEngine;

public class ActivateTrap : MonoBehaviour
{
    public TrapActivator trapActivator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            trapActivator.ActivateTrap();
        }
    }

}
