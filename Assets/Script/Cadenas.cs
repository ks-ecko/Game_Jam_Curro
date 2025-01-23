using UnityEngine;

public class Cadenas : MonoBehaviour
{
    public string nombreAnimación;
    public Animator animator;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.Play(nombreAnimación);
            Destroy(gameObject);
        }
    }
}
