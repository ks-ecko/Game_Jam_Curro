using UnityEngine;

public class Cadenas : MonoBehaviour
{
    public GameObject cadena;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cadena.SetActive (false);
        }
    }
}
