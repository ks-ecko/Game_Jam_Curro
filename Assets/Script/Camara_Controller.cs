using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Controller : MonoBehaviour
{
    public Vector2 sensitivity;
    private Vector2 angle;
    public Transform follow;
    public float distance;

  
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        // Invertir el movimiento horizontal del ratón
        if (hor != 0)
        {
            angle.x -= hor * Mathf.Deg2Rad * sensitivity.x;
        }

        // Invertir el eje Y
        if (ver != 0)
        {
            angle.y -= ver * Mathf.Deg2Rad * sensitivity.y;
            angle.y = Mathf.Clamp(angle.y, -80 * Mathf.Deg2Rad, 80 * Mathf.Deg2Rad);
        }
    }

   
    void LateUpdate()
    {
        Vector3 orbit = new Vector3(Mathf.Cos(angle.x) * Mathf.Cos(angle.y), Mathf.Sin(angle.y), Mathf.Sin(angle.x) * Mathf.Cos(angle.y));
        transform.position = follow.position + orbit * distance;
        transform.rotation = Quaternion.LookRotation(follow.position - transform.position);
    }
}
