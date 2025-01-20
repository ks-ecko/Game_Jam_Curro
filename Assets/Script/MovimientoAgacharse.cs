using UnityEngine;

public class MovimientoAgacharse : MonoBehaviour
{
    public bool crouch;
    public float smoothCrouch = 5.0f;

    // Collider y cámara
    private CapsuleCollider col;
    public Transform cam; // Cámara del jugador

    private Vector3 escalaOriginal;
    private float alturaOriginal;
    private Vector3 posicionCamOriginal;

    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        escalaOriginal = transform.localScale;
        alturaOriginal = col.height;
        posicionCamOriginal = cam.localPosition;
    }

    public void ActualizarEstado(bool agacharse)
    {
        crouch = agacharse;

        // Cambiar escala del personaje
        Vector3 targetScale = crouch ? new Vector3(1, 0.65f, 1) : escalaOriginal;
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, smoothCrouch * Time.deltaTime);

        // Ajustar el collider
        col.height = crouch ? 1.0f : alturaOriginal;
        col.center = crouch ? new Vector3(0, 0.5f, 0) : new Vector3(0, 1.0f, 0);

        // Ajustar posición de la cámara
        Vector3 targetCamPos = crouch ? new Vector3(0, 0.5f, 0) : posicionCamOriginal;
        cam.localPosition = Vector3.Lerp(cam.localPosition, targetCamPos, smoothCrouch * Time.deltaTime);
    }
}
