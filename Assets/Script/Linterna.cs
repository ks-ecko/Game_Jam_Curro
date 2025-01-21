using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Linterna : MonoBehaviour
{
    public Light luzLinterna;
    public bool activLight;
    public float BateriaRest;
    public float AgoteBateria = 0.5f;
    public TMP_Text porcentaje;
    public float RecargaBat = 25f;
    // Update is called once per frame
    void Update()
    {

        BateriaRest = Mathf.Clamp(BateriaRest, 0, 100);
        int valorBateria = (int) BateriaRest;
        porcentaje.text = valorBateria.ToString() + "%";
        
        //este script es el de encender y apagar la linterna
        if(Input.GetMouseButtonDown(1))
        {
            activLight = !activLight;
        
            if(activLight == true)
            {
                luzLinterna.enabled = true;
            }

            if(activLight == false)
            {
                luzLinterna.enabled = false;
            }
        }
        
        if(activLight ==true && BateriaRest >0)
        {
            BateriaRest -= AgoteBateria * Time.deltaTime;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Pila")
        {
            
            BateriaRest += RecargaBat;
        }
    }
}
