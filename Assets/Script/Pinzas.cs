using UnityEngine;

public class Pinzas : MonoBehaviour
{
    public GameObject ColliderCadena;
    public GameObject ColliderPuertaCerrada;
    public GameObject handPoint; // Punto donde se colocará el objeto
    private GameObject pickedObject = null;
    public bool pickedHVYobject = false;
    public bool keyAdquired = false;
    
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
            pickedHVYobject = false;
            keyAdquired = false;
            
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
        if (other.gameObject.CompareTag("Pinzas") && Input.GetKey("e") && pickedObject == null)
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

            pickedHVYobject = true;


        }
        if (other.gameObject.CompareTag("Llave") && Input.GetKey("e") && pickedObject == null)
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

            keyAdquired = true;
        }
    }
    private void FixedUpdate()
    {
        if (pickedHVYobject == true)
        {
            ColliderCadena.gameObject.SetActive(true);
        }
        if (keyAdquired == true)
        {
            ColliderPuertaCerrada.gameObject.SetActive(true);
        }
    }

    public bool GetpickedHVYobject() 
    {
        return pickedHVYobject;
    }
}
