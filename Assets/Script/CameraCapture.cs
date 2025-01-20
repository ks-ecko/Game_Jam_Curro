using UnityEngine;

public class CameraCapture : MonoBehaviour
{
    public Camera playerCamera;
    public KeyCode captureKey = KeyCode.C;
    public string captureFolder = "CapturedImages";
    public PhotoInventory inventory;

    void Start()
    {
        if (!System.IO.Directory.Exists(captureFolder))
        {
            System.IO.Directory.CreateDirectory(captureFolder);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(captureKey))
        {
            TakePhoto();
        }
    }

    void TakePhoto()
    {
        string fileName = $"{captureFolder}/photo_{System.DateTime.Now.ToString("yyyyMMdd_HHmmss")}.png";
        ScreenCapture.CaptureScreenshot(fileName);

        Debug.Log($"Foto tomada: {fileName}");

        // Agregar la foto al inventario
        inventory.AddPhoto(fileName);
    }
}
