using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabla : MonoBehaviour
{
    public int numero1=7;
    public int numero2=0;
    private int resultado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numero2<=10)
        {
            resultado=numero1*numero2;
            Debug.Log(numero1+"*"+numero2+"="+resultado);
            numero2++;

        Debug.Log ("Hola");
        }
    }
}
