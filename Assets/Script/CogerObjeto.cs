using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
    public GameObject handPoint; // Punto donde se colocará el objeto
    private GameObject pickedObject = null;

    void Update()
    {
        // Soltar el objeto
        if (pickedObject != null && Input.GetKey("q"))
        {
            Rigidbody rb = pickedObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
            }

            Collider collider = pickedObject.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = true; // Reactivar colisiones
            }

            pickedObject.transform.SetParent(null); // Quitar la jerarquía
            pickedObject = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Recoger el objeto
        if (other.gameObject.CompareTag("Objeto") && Input.GetKey("e") && pickedObject == null)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false;
                rb.isKinematic = true; // Desactivar físicas
            }

            Collider collider = other.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false; // Evitar colisiones con el jugador
            }

            other.transform.position = handPoint.transform.position;
            other.transform.rotation = handPoint.transform.rotation;

            other.transform.SetParent(handPoint.transform); // Hacerlo hijo del punto
            pickedObject = other.gameObject;
        }
    }
}
