using UnityEngine;
using TMPro;
using System.Collections;

public class PhotoCapture : MonoBehaviour
{

    public AudioSource cameraSound;  // Referencia al AudioSource
    public Camera playerCamera; // Cámara del jugador (por ahora no se usa)
    public TextMeshProUGUI photoTakenText; // Texto de confirmación
    private bool canTakePhoto = false; // Control para tomar fotos solo en áreas válidas

    // Referencia al PhotoGalleryManager
    public PhotoGalleryManager galleryManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canTakePhoto)
        {
            // Reproducir el sonido de la cámara
            cameraSound.Play();

            // Llamar a la corutina para capturar la foto
            StartCoroutine(CapturePhoto());
        }
        // Detectar entrada del jugador
        if (Input.GetKeyDown(KeyCode.F) && canTakePhoto)
        {
            // Llamar a la corutina para capturar la foto
            StartCoroutine(CapturePhoto());
        }
    }

    IEnumerator CapturePhoto()
    {
        // Llamamos a la corutina para tomar la foto y esperamos que termine
        yield return StartCoroutine(TakeScreenshotCoroutine());

        // Si la foto se capturó correctamente, agregarla a la galería
        if (capturedPhoto != null)
        {
            galleryManager.AddPhotoToGallery(capturedPhoto);

            // Mostrar el mensaje de confirmación
            photoTakenText.gameObject.SetActive(true);
            photoTakenText.text = "¡Foto tomada!";

            // Ocultar el mensaje después de 1 segundo
            Invoke("HidePhotoText", 1f);
        }
    }

    private Sprite capturedPhoto;

    IEnumerator TakeScreenshotCoroutine()
    {
        // Iniciar la corutina para tomar la foto
        yield return StartCoroutine(galleryManager.CapturePhotoCoroutine((photoSprite) => {
            capturedPhoto = photoSprite; // Guardar el Sprite capturado
        }));
    }

    private void OnTriggerEnter(Collider other)
    {
        // Activar el permiso para tomar fotos si el jugador entra en un área válida
        if (other.CompareTag("PhotoArea"))
        {
            canTakePhoto = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Desactivar el permiso si el jugador sale del área válida
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
