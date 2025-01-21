using UnityEngine;

public class PhotoAreaTrigger : MonoBehaviour
{
    public bool canTakePhoto = false; // Indica si se puede tomar una foto

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tiene la etiqueta "Player"
        {
            canTakePhoto = true;
             Debug.Log("Jugador ha entrado en el área de foto");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTakePhoto = false;
             Debug.Log("Jugador salió");
        }
    }
}
