using UnityEngine;

public class CamaraPrimeraPersona : MonoBehaviour
{
    public float rotSpeed = 5f;  // Velocidad de rotación de la cámara
    public float rotMin = -45f, rotMax = 45f;  // Límite de rotación vertical

    private float mouseX, mouseY;  // Acumuladores de rotación

    void Start()
    {
        // Oculta el cursor y lo bloquea en el centro de la pantalla
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Inicializa la rotación de la cámara
        Vector3 angles = transform.eulerAngles;
        mouseX = angles.y;
        mouseY = angles.x;
    }

    void Update()
    {
        // Control de rotación con el ratón
        RotateCamera();
    }

    void RotateCamera()
    {
        // Calcula la rotación con el ratón
        mouseX += rotSpeed * Input.GetAxis("Mouse X");
        mouseY -= rotSpeed * Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, rotMin, rotMax); // Restringe la rotación vertical

        // Aplica la rotación a la cámara
        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
    }
}
