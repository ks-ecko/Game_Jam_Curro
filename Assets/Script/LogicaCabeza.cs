using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaCabeza : MonoBehaviour
{
    public int contadorDeColision = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        contadorDeColision++;
    }

    private void OnTriggerExit(Collider other)
    {
        contadorDeColision--;
    }
}
