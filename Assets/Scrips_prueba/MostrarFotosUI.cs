using UnityEngine;
using UnityEngine.UI;

public class MostrarFotosUI : MonoBehaviour
{
    public InventarioFotos inventario;  // Referencia al inventario de fotos
    public GameObject panelFotos;  // Panel donde se mostrarán las fotos
    public GameObject fotoPrefab;  // Prefab de la foto (un GameObject con un componente Image)

    void Start()
    {
        if (panelFotos == null || fotoPrefab == null)
        {
            Debug.LogError("Faltan referencias en el script de MostrarFotosUI");
        }
    }

    void Update()
    {
        MostrarFotos();
    }

    // Método para mostrar las fotos en la UI
    void MostrarFotos()
    {
        // Limpiar el panel de fotos antes de agregar las nuevas fotos
        foreach (Transform child in panelFotos.transform)
        {
            Destroy(child.gameObject);  // Eliminar fotos anteriores
        }

        // Crear una nueva imagen por cada foto en el inventario
        foreach (Texture2D foto in inventario.fotos)
        {
            GameObject nuevaFoto = Instantiate(fotoPrefab, panelFotos.transform);
            Image img = nuevaFoto.GetComponent<Image>();

            // Convertir la textura a sprite
            Sprite spriteFoto = Sprite.Create(foto, new Rect(0, 0, foto.width, foto.height), new Vector2(0.5f, 0.5f));
            img.sprite = spriteFoto;
        }
    }
}
