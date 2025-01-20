using UnityEngine;
using System.Collections.Generic;

public class TomarFoto : MonoBehaviour
{
    public List<Texture2D> fotos = new List<Texture2D>();  // Lista para guardar las fotos
    public Camera camara;  // Cámara principal (asegurate de asignarla en el inspector)
    private bool puedeSacarFoto = false;

    void Update()
    {
        // Si el jugador puede tomar la foto y presiona la tecla F
        if (puedeSacarFoto && Input.GetKeyDown(KeyCode.F))
        {
            TomarFotoYGuardar();
        }
    }

    // Función que toma una foto y la guarda en el inventario
    void TomarFotoYGuardar()
    {
        RenderTexture renderTexture = new RenderTexture(1920, 1080, 24);
        camara.targetTexture = renderTexture;
        camara.Render();

        Texture2D foto = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        foto.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        foto.Apply();

        fotos.Add(foto);  // Guardar la foto en la lista de fotos

        // Resetear para liberar recursos
        camara.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);
    }

    // Detectar cuando el jugador entra a una zona donde puede sacar foto
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZonaFoto"))
        {
            puedeSacarFoto = true;
            // Puedes activar un mensaje en UI o algo visual para indicar que ahora puede sacar la foto
        }
    }

    // Detectar cuando el jugador sale de la zona
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ZonaFoto"))
        {
            puedeSacarFoto = false;
            // Desactivar el mensaje en UI o cualquier indicación visual
        }
    }
}
