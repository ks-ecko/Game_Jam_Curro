using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_2 : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        thePlayer.transform.position = teleportTarget.position;
    }

    
    void Update()
    {
        
    }
}
