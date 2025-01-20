using UnityEngine;

public class ZonaFoto : MonoBehaviour
{
    // No necesitamos mucho código aquí, solo asegúrate de que el collider esté marcado como "Is Trigger"
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Podríamos mostrar un mensaje como "Presiona F para sacar una foto"
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aquí podrías ocultar el mensaje de que se puede sacar una foto
        }
    }
}
