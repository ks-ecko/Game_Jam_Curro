using UnityEngine;
using TMPro;

public class PhotoCapture : MonoBehaviour
{
    public Camera playerCamera;
    public TextMeshProUGUI photoTakenText;
    private bool canTakePhoto = false;

    // Referencia al PhotoGalleryManager
    public PhotoGalleryManager galleryManager; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canTakePhoto)
        {
            CapturePhoto();
        }
    }

    void CapturePhoto()
    {
        // Crear la captura de la foto como un Sprite
        Sprite newPhoto = galleryManager.CapturePhoto();

        // Agregar la foto a la galería
        galleryManager.AddPhotoToGallery(newPhoto);

        // Mostrar el mensaje de alerta
        photoTakenText.gameObject.SetActive(true);
        photoTakenText.text = "¡Foto tomada!";

        // Desaparecer el mensaje después de 1 segundo
        Invoke("HidePhotoText", 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PhotoArea"))
        {
            canTakePhoto = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PhotoArea"))
        {
            canTakePhoto = false;
        }
    }

    void HidePhotoText()
    {
        photoTakenText.gameObject.SetActive(false);
    }
}
    