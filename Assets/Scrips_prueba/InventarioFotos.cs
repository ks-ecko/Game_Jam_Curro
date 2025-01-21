using System.Collections.Generic;
using UnityEngine;

public class InventarioFotos : MonoBehaviour
{
    public List<Texture2D> fotos = new List<Texture2D>();  // Lista para guardar las fotos
    public Transform cam;  // Referencia a la c�mara
    public Camera fotoCam;  // C�mara adicional para sacar la foto (si quieres usar otra c�mara)

    private bool puedeSacarFoto = false;

    void Update()
    {
        // Detectar si el jugador est� en una zona v�lida y presiona el bot�n para tomar la foto
        if (puedeSacarFoto && Input.GetKeyDown(KeyCode.F)) // F para sacar foto
        {
            Debug.Log("Se presion� F para sacar foto");
            TomarFoto();
        }
    }

    // Funci�n que toma una foto y la guarda en el inventario
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

    // Detectar cuando el jugador est� en una zona v�lida para tomar fotos
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZonaFoto"))
        {
            puedeSacarFoto = true;
            // Aqu� puedes mostrar un mensaje o cambiar UI para indicar que se puede tomar una foto
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ZonaFoto"))
        {
            puedeSacarFoto = false;
            // Aqu� puedes ocultar el mensaje o cambiar la UI
        }
    }
}
