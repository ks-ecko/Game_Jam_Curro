using UnityEngine;
using UnityEngine.AI;

public class Logica_Enemigo : MonoBehaviour
{
    public Transform Objetivo; // El objetivo que el enemigo sigue
    public float Velocidad = 3.5f; // Velocidad del enemigo
    public NavMeshAgent IA; // El componente de NavMeshAgent del enemigo
    private bool estaCongelado = false; // Si el enemigo está congelado

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
        // Solo se mueve si no está congelado
        if (!estaCongelado)
        {
            IA.speed = Velocidad;
            IA.SetDestination(Objetivo.position);
        }
    }

    // Método para activar o desactivar el congelamiento del enemigo
    public void SerIluminado(bool iluminado)
    {
        estaCongelado = iluminado;

        // Congelar al enemigo si está iluminado
        if (iluminado)
        {
            IA.isStopped = true; // Detener al agente
        }
        else
        {
            IA.isStopped = false; // Dejar que se mueva otra vez
        }
    }
}
