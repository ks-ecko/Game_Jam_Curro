using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
    public GameObject handPoint; // Punto donde se colocará el objeto
    private GameObject pickedObject = null;

    void Update()
    {
        // Soltar el objeto con la tecla "Q"
        if (pickedObject != null && Input.GetKeyDown(KeyCode.Q))
        {
            SoltarObjeto();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Recoger el objeto con la tecla "E"
        if (other.gameObject.CompareTag("Objeto") && Input.GetKeyDown(KeyCode.E) && pickedObject == null)
        {
            RecogerObjeto(other.gameObject);
        }
    }

    private void RecogerObjeto(GameObject objeto)
    {
        // Desactivar la gravedad y físicas del objeto
        Rigidbody rb = objeto.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        // Desactivar las colisiones del objeto
        Collider col = objeto.GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }

        // Ajustar la posición y rotación del objeto al `HandPoint`
        objeto.transform.position = handPoint.transform.position;
        objeto.transform.rotation = handPoint.transform.rotation; // Alinea la rotación con el `HandPoint`

        // Asegurar orientación específica para la linterna (opcional)
        if (objeto.name == "Linterna") // Cambia este nombre según tu objeto
        {
            objeto.transform.localRotation = Quaternion.Euler(0, 0, 0); // Ajusta si hace falta.
        }

        // Hacer que el objeto sea hijo del `HandPoint`
        objeto.transform.SetParent(handPoint.transform);

        // Guardar el objeto recogido
        pickedObject = objeto;
    }

    private void SoltarObjeto()
    {
        if (pickedObject == null) return;

        // Activar la gravedad y físicas del objeto
        Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }

        // Reactivar las colisiones del objeto
        Collider col = pickedObject.GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = true;
        }

        // Desvincular el objeto del `HandPoint`
        pickedObject.transform.SetParent(null);

        // Eliminar referencia al objeto recogido
        pickedObject = null;
    }
}
