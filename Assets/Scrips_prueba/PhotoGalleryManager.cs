using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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

    // Método para capturar una foto
    public Sprite CapturePhoto()
    {
        // Crear una textura con la captura de la pantalla
        Texture2D screenshotTexture = ScreenCapture.CaptureScreenshotAsTexture();

        // Convertir la textura en un Sprite
        Sprite photoSprite = Sprite.Create(
            screenshotTexture,
            new Rect(0, 0, screenshotTexture.width, screenshotTexture.height),
            new Vector2(0.5f, 0.5f)
        );

        return photoSprite;
    }

    // Llamar a este método desde otro script para tomar una foto y agregarla a la galería
    public void TakePhoto()
    {
        Sprite newPhoto = CapturePhoto(); // Capturar una nueva foto
        AddPhotoToGallery(newPhoto);     // Agregarla a la galería
        Debug.Log("Foto capturada y añadida a la galería.");
    }
}
