using UnityEngine;

public class PhotoDebug : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // Al presionar la tecla P
        {
            PhotoGalleryManager galleryManager = FindObjectOfType<PhotoGalleryManager>();
            if (galleryManager != null)
            {
                galleryManager.TakePhoto();
                Debug.Log("Foto tomada mediante la tecla P.");
            }
            else
            {
                Debug.LogWarning("No se encontró el script PhotoGalleryManager en la escena.");
            }
        }
    }
}
