using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Linterna : MonoBehaviour
{
    public float RangoLinterna = 15f; // Rango de la linterna
    public Camera camara; // Cámara desde la cual se lanzará el Raycast

    public Light luzLinterna;
    public bool activLight;
    public float BateriaRest;
    public float AgoteBateria = 0.5f;
    public TMP_Text porcentaje;
    public float RecargaBat = 25f;

    void Update()
    {
        // Asegurarse de que la batería no se pase de 0 a 100
        BateriaRest = Mathf.Clamp(BateriaRest, 0, 100);
        int valorBateria = (int)BateriaRest;
        porcentaje.text = valorBateria.ToString() + "%";

        // Depuración: Verificar el valor de la batería
        Debug.Log("Batería Restante: " + BateriaRest);

        // Este bloque controla encender y apagar la linterna solo si la batería es mayor que 0
        if (Input.GetMouseButtonDown(1))  // Detectar click derecho
        {
            // Depuración: Verificar si se ha presionado el botón y el estado de la batería
            Debug.Log("Click derecho detectado. Activando linterna...");

            if (BateriaRest > 0)  // Solo encender si la batería tiene carga
            {
                activLight = !activLight;

                if (activLight)
                {
                    luzLinterna.enabled = true;
                    Debug.Log("Linterna encendida.");
                }
                else
                {
                    luzLinterna.enabled = false;
                    Debug.Log("Linterna apagada.");
                }
            }
            else
            {
                // Depuración: Mensaje si la batería está vacía
                Debug.Log("No se puede encender la linterna. Batería agotada.");
            }
        }

        // Si la linterna está encendida y hay batería, reducir el nivel de batería
        if (activLight && BateriaRest > 0)
        {
            BateriaRest -= AgoteBateria * Time.deltaTime;
        }

        // Si la batería llega a cero, desactivar la linterna
        if (BateriaRest <= 0 && luzLinterna.enabled == true)
        {
            luzLinterna.enabled = false;
            activLight = false;
            Debug.Log("Linterna apagada debido a batería agotada.");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Al entrar en contacto con una batería, recargarla
        if (other.CompareTag("Pila"))
        {
            BateriaRest += RecargaBat;
            // Depuración: Verificar cuando recargamos la batería
            Debug.Log("Batería recargada. Batería restante: " + BateriaRest);
        }
    }

    void OnDrawGizmos()
    {
        // Dibujar un rayo que representa el rango de la linterna en la escena
        if (camara != null)
        {
            Ray ray = camara.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(ray.origin, ray.direction * RangoLinterna);
        }
    }
}