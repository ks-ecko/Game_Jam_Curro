using System.Collections.Generic;
using UnityEngine;

public class InventarioFotos : MonoBehaviour
{
    public List<Texture2D> fotos = new List<Texture2D>();  // Lista para guardar las fotos
    public Transform cam;  // Referencia a la cámara
    public Camera fotoCam;  // Cámara adicional para sacar la foto (si quieres usar otra cámara)

    private bool puedeSacarFoto = false;

    void Update()
    {
        // Detectar si el jugador está en una zona válida y presiona el botón para tomar la foto
        if (puedeSacarFoto && Input.GetKeyDown(KeyCode.F)) // F para sacar foto
        {
            Debug.Log("Se presionó F para sacar foto");
            TomarFoto();
        }
    }

    // Función que toma una foto y la guarda en el inventario
    void TomarFoto()
    {
        RenderTexture renderTexture = new RenderTexture(1920, 1080, 24);
        fotoCam.targetTexture = renderTexture;
        fotoCam.Render();

        Texture2D foto = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        foto.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        foto.Apply();

        fotos.Add(foto);  // Guardar la foto en el inventario

        Debug.Log("Foto agregada. Total fotos: " + fotos.Count);

        fotoCam.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);  // Liberar recursos
    }

    // Detectar cuando el jugador está en una zona válida para tomar fotos
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZonaFoto"))
        {
            puedeSacarFoto = true;
            // Aquí puedes mostrar un mensaje o cambiar UI para indicar que se puede tomar una foto
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ZonaFoto"))
        {
            puedeSacarFoto = false;
            // Aquí puedes ocultar el mensaje o cambiar la UI
        }
    }
}
