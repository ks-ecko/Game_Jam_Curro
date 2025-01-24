using UnityEngine;

public class Cadenas : MonoBehaviour
{
    public string nombreAnimaci�n;
    public Animator animator;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.Play(nombreAnimaci�n);
            Destroy(gameObject);
        }
    }
}
