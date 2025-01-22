using UnityEngine;

public class GalleryUIManager : MonoBehaviour
{
    public GameObject galleryPanel; // El panel de la galería que se abre/cierra
    public Transform content; // El contenedor con GridLayoutGroup para las fotos
    public GameObject photoSlotPrefab; // Prefab de cada foto

    private bool isGalleryOpen = false; // Estado del panel de la galería

    void Update()
    {
        // Cambiar el estado de la galería con la tecla "I"
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Se presionó la tecla 'I'. Intentando alternar la galería...");
            ToggleGallery();
        }
    }

    // Alterna el estado del panel de la galería
    public void ToggleGallery()
    {
        isGalleryOpen = !isGalleryOpen; // Cambiar el estado
        galleryPanel.SetActive(isGalleryOpen); // Activar o desactivar el panel
        Debug.Log($"Galería {(isGalleryOpen ? "abierta" : "cerrada")}."); // Mensaje de depuración
    }

    // Método para añadir una foto al grid
    public void AddPhoto(Sprite photo)
    {
        if (photo == null)
        {
            Debug.LogWarning("No se pudo añadir una foto porque el sprite es nulo.");
            return;
        }

        // Crear un nuevo slot para la foto
        GameObject newSlot = Instantiate(photoSlotPrefab, content);
        var photoImage = newSlot.GetComponent<UnityEngine.UI.Image>();

        if (photoImage != null)
        {
            photoImage.sprite = photo; // Asignar la foto al Image del prefab
            Debug.Log("Foto añadida al inventario.");
        }
        else
        {
            Debug.LogWarning("El prefab no tiene un componente Image.");
        }
    }
}
