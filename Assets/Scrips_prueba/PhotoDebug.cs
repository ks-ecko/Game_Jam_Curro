using UnityEngine;

public class PhotoDebug : MonoBehaviour
{
    // Referencia al PhotoGalleryManager
    public PhotoGalleryManager galleryManager;

    void Update()
    {
        // Al presionar la tecla F, tomar la foto
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Llamamos a la corutina para tomar la foto
            StartCoroutine(galleryManager.CapturePhotoCoroutine((photoSprite) =>
            {
                if (photoSprite != null)
                {
                    // Aquí puedes hacer algo con la foto capturada, por ejemplo, agregarla a la galería
                    galleryManager.AddPhotoToGallery(photoSprite);
                    Debug.Log("Foto capturada y añadida a la galería.");
                }
                else
                {
                    Debug.LogError("No se pudo capturar la foto.");
                }
            }));
        }
    }
}
