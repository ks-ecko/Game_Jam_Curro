using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiedoYDistorsion : MonoBehaviour
{
    [Header("Configuración del Miedo")]
    public float nivelMiedo = 0f; // Nivel actual de miedo
    public float maxMiedo = 100f; // Nivel máximo de miedo
    public float aumentoPorSegundo = 10f; // Incremento por segundo cerca del enemigo
    public float disminucionPorSegundo = 5f; // Disminución por segundo lejos del enemigo

    [Header("Barra de Miedo")]
    public Image barraMiedo; // Referencia al relleno de la barra de miedo
    public Gradient colorBarra; // Gradiente para cambiar el color de la barra

    [Header("Cambio de Caras")]
    public Image caraMiedo; // Imagen de la cara
    public Sprite caraTranquila;
    public Sprite caraMedia;
    public Sprite caraAsustada;

    [Header("Efecto de Distorsión")]
    public CanvasGroup distorsionPantalla; // CanvasGroup para controlar la opacidad

    [Header("Audio")]
    public AudioSource latidosCorazon;
    public float umbralLatidos = 50f; // Nivel de miedo para activar los latidos

    [Header("Configuración del Enemigo")]
    public Transform enemigo; // Referencia al enemigo
    public Transform jugador; // Referencia al jugador
    public float distanciaCercana = 10f; // Distancia para aumentar el miedo

    private void Update()
    {
        // Verificar que el jugador está asignado
        if (jugador == null)
        {
            Debug.LogWarning("Jugador no asignado en el script MiedoYDistorsion.");
            return;
        }

        // Calcular distancia al enemigo
        float distancia = Vector3.Distance(jugador.position, enemigo.position);

        // Aumentar o disminuir el miedo según la distancia
        if (distancia <= distanciaCercana)
        {
            nivelMiedo += aumentoPorSegundo * Time.deltaTime;
        }
        else
        {
            nivelMiedo -= disminucionPorSegundo * Time.deltaTime;
        }

        // Clamp del nivel de miedo
        nivelMiedo = Mathf.Clamp(nivelMiedo, 0f, maxMiedo);

        // Actualizar barra de miedo
        float porcentajeMiedo = nivelMiedo / maxMiedo;
        barraMiedo.fillAmount = porcentajeMiedo;
        barraMiedo.color = colorBarra.Evaluate(porcentajeMiedo);

        // Cambiar la cara según el nivel de miedo
        if (nivelMiedo < maxMiedo / 3)
        {
            caraMiedo.sprite = caraTranquila;
        }
        else if (nivelMiedo < (2 * maxMiedo) / 3)
        {
            caraMiedo.sprite = caraMedia;
        }
        else
        {
            caraMiedo.sprite = caraAsustada;
        }

        // Controlar opacidad del efecto de distorsión
        distorsionPantalla.alpha = nivelMiedo / maxMiedo;

        // Controlar los latidos del corazón
        if (nivelMiedo >= umbralLatidos && !latidosCorazon.isPlaying)
        {
            latidosCorazon.Play();
        }
        else if (nivelMiedo < umbralLatidos && latidosCorazon.isPlaying)
        {
            latidosCorazon.Stop();
        }
    }
}
