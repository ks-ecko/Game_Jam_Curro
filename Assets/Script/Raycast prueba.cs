using UnityEngine;

public class Raycastprueba : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(1))  // Detectar click derecho
        {
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 20f);
        }
    }
}