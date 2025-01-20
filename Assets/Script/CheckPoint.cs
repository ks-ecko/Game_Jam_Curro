using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Vector3 checkpoint;

    void Start ()
    {
        checkpoint = this.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "CheckPoint")
        {
            checkpoint = this.transform.position;
        }

        if (other.tag == "FallDetector")
        {
            transform.position = checkpoint;
        }
    }
}