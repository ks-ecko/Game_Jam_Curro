using UnityEngine;

public class Puertadellave : MonoBehaviour
{
    public GameObject puerta;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puerta.SetActive(false);
        }
    }
}