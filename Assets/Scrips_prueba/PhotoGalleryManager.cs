using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;  // Asegúrate de incluir esto para usar corutinas

public class PhotoGalleryManager : MonoBehaviour
{
    public GameObject photoSlotPrefab; // Prefab para cada foto en la galería
    public Transform galleryPanel; // Panel donde se mostrarán las fotos
    private List<Sprite> photos = new List<Sprite>(); // Lista para almacenar las fotos tomadas

    // Método para añadir una foto a la galería
    public void AddPhotoToGallery(Sprite photo)
    {
        if (photo == null) return; // Verifica que la foto no sea nula

        // Añadir la foto a la lista
        photos.Add(photo);

        // Crear un nuevo "slot" en la galería y asignarle la foto
        GameObject newSlot = Instantiate(photoSlotPrefab, galleryPanel);
        Image photoImage = newSlot.GetComponent<Image>();

        if (photoImage != null)
        {
            photoImage.sprite = photo;
        }
        else
        {
            Debug.LogWarning("El prefab no tiene un componente Image.");
        }
    }

    // Método para capturar una foto con corutina
    public IEnumerator CapturePhotoCoroutine(System.Action<Sprite> onCaptureComplete)
    {
        // Espera hasta el final del frame actual para hacer la captura de pantalla
        yield return new WaitForEndOfFrame();

        // Crear una textura con la captura de la pantalla
        Texture2D screenshotTexture = ScreenCapture.CaptureScreenshotAsTexture();

        // Verificar si la textura se creó correctamente
        if (screenshotTexture != null)
        {
            // Convertir la textura en un Sprite
            Sprite photoSprite = Sprite.Create(
                screenshotTexture,
                new Rect(0, 0, screenshotTexture.width, screenshotTexture.height),
                new Vector2(0.5f, 0.5f)
            );

            // Llamamos a la acción para pasar la foto capturada
            onCaptureComplete?.Invoke(photoSprite);
        }
        else
        {
            Debug.LogError("No se pudo capturar la pantalla. La textura es nula.");
            onCaptureComplete?.Invoke(null);
        }
    }
}
