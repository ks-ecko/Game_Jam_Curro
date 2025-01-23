using UnityEngine;

public class Logica_Linterna : MonoBehaviour
{
    public BoxCollider zonaLinterna; // Collider en forma de caja para el rango de la linterna
    public float RangoLinterna = 15f; // Rango de la linterna

    void Start()
    {
        // Configurar el collider de la linterna para que actúe como un trigger
        if (zonaLinterna == null)
        {
            zonaLinterna = GetComponent<BoxCollider>();
        }

        // Ajustar el rango de la linterna
        zonaLinterna.size = new Vector3(RangoLinterna, RangoLinterna, RangoLinterna); // Ajusta el tamaño de la caja
        zonaLinterna.isTrigger = true; // Asegurarnos de que sea un trigger
    }

    // Detectar cuando el enemigo entra en el rango de la linterna
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo_2")) // Asegúrate de que el enemigo tenga la etiqueta "Enemigo"
        {
            Logica_Enemigo enemigo = other.GetComponent<Logica_Enemigo>();
            if (enemigo != null)
            {
                enemigo.SerIluminado(true); // Congelar al enemigo
            }
        }
    }

    // Detectar cuando el enemigo sale del rango de la linterna
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemigo_2"))
        {
            Logica_Enemigo enemigo = other.GetComponent<Logica_Enemigo>();
            if (enemigo != null)
            {
                enemigo.SerIluminado(false); // Liberar al enemigo
            }
        }
    }
}
