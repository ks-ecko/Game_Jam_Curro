using UnityEngine;

public class ZonaFoto : MonoBehaviour
{
    // No necesitamos mucho c�digo aqu�, solo aseg�rate de que el collider est� marcado como "Is Trigger"
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Podr�amos mostrar un mensaje como "Presiona F para sacar una foto"
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aqu� podr�as ocultar el mensaje de que se puede sacar una foto
        }
    }
}
