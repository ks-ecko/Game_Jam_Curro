using UnityEngine;
using UnityEngine.UI;

public class PhotoInventoryManager : MonoBehaviour
{
    public GameObject photoSlotPrefab; // Prefab de las celdas de foto
    public Transform inventoryPanel;   // Panel donde se mostrarán las fotos
    public GameObject inventoryButton; // Botón para abrir/cerrar el inventario

    private bool isInventoryOpen = false;

    void Start()
    {
        // Asegurarnos de que el inventario comience cerrado
        inventoryPanel.gameObject.SetActive(false);
    }

    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryPanel.gameObject.SetActive(isInventoryOpen);
    }

    public void AddPhotoToInventory(Sprite photoSprite)
    {
        // Crear una nueva celda de foto
        GameObject newPhotoSlot = Instantiate(photoSlotPrefab, inventoryPanel);
        // Asignar la imagen de la foto al Image del prefab
        newPhotoSlot.GetComponent<Image>().sprite = photoSprite;
    }
}
