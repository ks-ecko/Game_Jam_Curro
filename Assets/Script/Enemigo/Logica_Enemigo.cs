using UnityEngine;
using UnityEngine.AI;

public class Logica_Enemigo : MonoBehaviour
{
    public Transform Objetivo; // El objetivo que el enemigo sigue
    public float Velocidad = 3.5f; // Velocidad del enemigo
    public float Stun = 3.5f;
    public NavMeshAgent IA; // El componente de NavMeshAgent del enemigo
    public bool estaCongelado = false; // Si el enemigo está congelado

    void Start()
    {
        // Asegurarse de que IA esté asignado
        if (IA == null)
        {
            IA = GetComponent<NavMeshAgent>();
        }
    }

    void Update()
    {
        if (estaCongelado == true)
        {
            IA.speed = Velocidad - Stun;
        }
        if (estaCongelado == false)
        {
            IA.speed = Velocidad;
            IA.SetDestination(Objetivo.position);
        }    
    }
        
        
    void OnTriggerStay (Collider other)
    {
        if (other.CompareTag("Stun") && other.CompareTag("Unstun"))
        {
           estaCongelado = true;
        }
        if (other.CompareTag("Unstun") && !other.CompareTag("Stun"))
        {
            estaCongelado = false;
        }
    }
}
