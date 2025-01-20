using System.Collections;
using UnityEngine;
using TMPro;

public class LogicaPersonaje1 : MonoBehaviour
{
    // Agacharse
    public bool crouch;
    private Vector3 targetScale;
    private float targetHeight;
    private Vector3 targetCenter;

    // UI
    private int puntuacion;
    public TMP_Text pts;
    public int contador;

    // Movimiento y animaciones
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    public float velCorrer = 7.0f;
    public float velocidadAgachado = 2.5f;
    private float velocidadBase; // Guardar el valor base de la velocidad de movimiento

    private float x, y; // Variables para los inputs de movimiento

    // Física
    private Rigidbody rb;
    private CapsuleCollider col;
    public Transform cam;

    void Awake()
    {
        puntuacion = 0;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>(); // Obtén el collider del personaje
        velocidadBase = velocidadMovimiento; // Guardar la velocidad inicial
        actualizarPts();

        // Establece los valores iniciales de la escala, altura y centro del collider
        targetScale = transform.localScale;
        targetHeight = col.height;
        targetCenter = col.center;
    }

    void FixedUpdate()
    {
        // Movimiento basado en la cámara
        Vector3 forward = cam.forward;
        Vector3 right = cam.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * y + right * x;

        if (moveDirection != Vector3.zero)
        {
            rb.MovePosition(rb.position + moveDirection * velocidadMovimiento * Time.fixedDeltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.MoveRotation(Quaternion.Lerp(transform.rotation, targetRotation, Time.fixedDeltaTime * velocidadRotacion));
        }

        // No se necesita suavidad, los cambios ya son instantáneos
        transform.localScale = targetScale;
        col.height = targetHeight;
        col.center = targetCenter;
    }

    void Update()
    {
        // Inputs de movimiento
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Verificar si está corriendo
        if (Input.GetKey(KeyCode.LeftShift) && !crouch) // No se puede correr mientras se está agachado
        {
            velocidadMovimiento = velCorrer;
        }
        else if (crouch) // Reducir la velocidad si está agachado
        {
            velocidadMovimiento = velocidadAgachado;
        }
        else
        {
            velocidadMovimiento = velocidadBase; // Restaurar la velocidad base
        }

        // Agacharse
        crouch = Input.GetKey(KeyCode.LeftControl);

        // Cambiar escala, altura y centro del collider
        if (crouch)
        {
            targetScale = new Vector3(1, 0.65f, 1);  // Escala al agacharse
            targetHeight = 1f; // Altura del collider al agacharse
            targetCenter = new Vector3(0, 0.5f, 0); // Centro del collider al agacharse
        }
        else
        {
            targetScale = new Vector3(1, 1, 1);  // Escala normal
            targetHeight = 2f; // Altura del collider en posición normal
            targetCenter = new Vector3(0, 0, 0); // Centro del collider en posición normal
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            contador++;
            puntuacion++;
            actualizarPts();
        }
    }

    void actualizarPts()
    {
        pts.text = "Puntuación: " + puntuacion.ToString();
    }
}
